using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxjar;
using WorkByrdLibrary.Configuration;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Extensions;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.Services
{
    public interface IPaymentService
    {
        public Stripe.Customer CreateCustomer(Company company);
        public Task<TaxResponseAttributes> CalculateTaxes(SubscriptionType subscription, string userID);
        public Task<PaymentIntent> CreatePaymentIntent(string stripeCustomerID, TaxResponseAttributes tax, SubscriptionType subscription);
        public Task<PaymentIntent> UpdatePaymentIntent(string paymentIntentID, TaxResponseAttributes tax, SubscriptionType subscription);
    }

    public class StripePaymentService : IPaymentService
    {
        public StripePaymentService(StripeConfig stripeConfig, ApplicationDbContext context)
        {
            _stripeConfig = stripeConfig;
            _context = context;
            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = _stripeConfig.SecretKey;
        }

        private StripeConfig _stripeConfig { get; set; }
        private ApplicationDbContext _context { get; set; }

        /// <summary>
        /// Creates a customer in the Stripe API for later use. We can use the customer's ID token along with our API token safely in our system without strict PCI compliance.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="payment_token"></param>
        /// <returns></returns>
        public Stripe.Customer CreateCustomer(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException("company");
            }
            if (string.IsNullOrWhiteSpace(company.Email))
            {
                throw new ArgumentNullException("company.Email");
            }
            if (string.IsNullOrWhiteSpace(company.Address1))
            {
                throw new ArgumentNullException("company.Address1");
            }
            if (string.IsNullOrWhiteSpace(company.City))
            {
                throw new ArgumentNullException("company.City");
            }
            if (company.StateProvinceID == 0)
            {
                throw new ArgumentNullException("company.StateProvinceID");
            }
            if (string.IsNullOrWhiteSpace(company.ZipCode))
            {
                throw new ArgumentNullException("company.ZipCode");
            }

            var query = from c in _context.Companies
                        join sp in _context.StateProvinces on c.StateProvinceID equals sp.ID
                        where c.StateProvinceID == company.StateProvinceID
                        select sp.Name;

            CustomerCreateOptions options = new CustomerCreateOptions();
            options.Email = company.Email;
            options.Address = new AddressOptions();
            options.Address.Line1 = company.Address1;
            options.Address.Line2 = company.Address2;
            options.Address.City = company.City;
            options.Address.State = query.FirstOrDefault();

            CustomerService service = new CustomerService();
            Stripe.Customer customer = service.Create(options);

            return customer;
        }

        //checks for nexus states. if no nexus then no calculation
        //if nexus then check cached results - cache results for 14 days?
        //    if no cached results then calculate no ones and save to the cache for later
        public async Task<TaxResponseAttributes> CalculateTaxes(SubscriptionType subscription, string userID)
        {
            if(string.IsNullOrWhiteSpace(userID)) {
                throw new ArgumentNullException("userID");
            }

            var query = from u in _context.Users
                        join e in _context.CompanyEmployees on u.Id equals e.UserID
                        join c in _context.Companies on e.CompanyID equals c.ID
                        join s in _context.StateProvinces on c.StateProvinceID equals s.ID
                        join co in _context.Countries on s.CountryID equals co.ID
                        join tj in _context.TaxJarCache on c.ID equals tj.Company_ID into taxjardetails from tjc in taxjardetails.DefaultIfEmpty() //LEFT JOIN
                        where u.Id == userID
                        select new { c, s, co, tjc };

            var data = query.FirstOrDefault();

            /*IF WE DO NOT HAVE NEXUS IN THE CUSTOMER'S STATE THEN WE WILL NOT COLLECT ANY TAXES*/
            if (data != null && !data.s.HasTaxNexus) return null;

            TaxResponseAttributes tax = new TaxResponseAttributes();

            StripeSubscriptions details = _stripeConfig.Subscriptions.Where(s => s.Name == subscription.GetDescription()).FirstOrDefault();
            decimal subscriptionCost = decimal.Parse(details.Cost.Replace("$", ""));

            //we need to calculate (or recalculate the taxes)
            if (data == null || data.tjc == null || DateTime.UtcNow > data.tjc.LastUpdatedDateUTC.AddDays(14)) //TODO - make 14 configurable...
            {                
                if (data == null)
                {
                    throw new ArgumentException("Unable to locate Company location data for tax calculations.");
                }

                //TODO
                /********************START - WHEN YOU HAVE A PAID TAXJAR SUBSCRIPTION****************************/
                //var client = new TaxjarApi("[Your TaxJar API Key here]");

                //tax = await client.TaxForOrderAsync(
                //    new
                //    {
                //        from_country = "US", //TODO - make this configurable?
                //        from_zip = "83706",
                //        from_state = "ID",
                //        from_city = "Boise",
                //        from_street = "", //TODO
                //        to_country = data.co.Abbreviation,
                //        to_zip = data.c.ZipCode,
                //        to_state = data.s.Abbreviation,
                //        to_city = data.c.City,
                //        to_street = data.c.Address1,
                //        amount = subscriptionCost,
                //        shipping = 0,
                //        nexus_address = new[]
                //        {
                //            new NexusAddress
                //            {
                //                Id = "Main Location",
                //                Country = "US",
                //                Zip = "83706",
                //                State = "ID",
                //                City = "Boise",
                //                Street = "" //TODO
                //            },
                //            new NexusAddress
                //            {
                //                Id = "Destination",
                //                Country = data.co.Abbreviation,
                //                Zip = data.c.ZipCode,
                //                State = data.s.Abbreviation,
                //                City = data.c.City,
                //                Street = data.c.Address1
                //            }
                //        },
                //        line_items = new[]
                //        {
                //            new Taxjar.LineItem
                //            {
                //                Id = "1",
                //                Quantity = 1,
                //                ProductTaxCode = details.TaxJarProductTaxCode,
                //                UnitPrice = subscriptionCost,
                //                Discount = 0,
                //                Description = $"WorkByrd - {details.Name} Subscription"
                //            }
                //        }
                //    }
                //);
                /********************END WHEN YOU HAVE A PAID SUBSCRIPTION****************************/

                /********************START TEST DATA****************************/
                tax = new TaxResponseAttributes(); //temporary assignment...
                tax.OrderTotalAmount = subscriptionCost * 1.07M;
                tax.Shipping = 0M;
                tax.TaxableAmount = subscriptionCost;
                tax.AmountToCollect = subscriptionCost * 0.07M;
                tax.Rate = 0.07M;
                tax.HasNexus = true;
                tax.FreightTaxable = false;
                tax.TaxSource = "destination";
                tax.Jurisdictions = new TaxJurisdictions();
                tax.Jurisdictions.Country = data.co.Abbreviation;
                tax.Jurisdictions.State = data.s.Abbreviation;
                tax.Jurisdictions.City = data.c.City;
                
                tax.Breakdown = new TaxBreakdown();
                tax.Breakdown.TaxableAmount = subscriptionCost;
                tax.Breakdown.TaxCollectable = subscriptionCost * 0.07M; //7% temporary tax rate since we have to pay for the TaxJar API...
                tax.Breakdown.CombinedTaxRate = 0.07M;
                tax.Breakdown.StateTaxableAmount = subscriptionCost;
                tax.Breakdown.StateTaxRate = 0.07M;
                tax.Breakdown.StateTaxCollectable = subscriptionCost * 0.07M;
                //there are more that we may not care about at the moment...
                /********************END TEST DATA****************************/
            }
            else
            {
                //otherwise we need to use the cached data here...
                tax = JsonConvert.DeserializeObject<TaxResponseAttributes>(data.tjc.TaxResponseAttributes);
                RecalculateTaxResponse(ref tax, details); //updates the cached response totals (but the rates should be correct) if it needs to be.
            }

            /******************************START CACHE RESULTS******************************/
            TaxJarCache cache = new TaxJarCache();
            cache.Company_ID = data.c.ID;
            cache.LastUpdatedDateUTC = DateTime.UtcNow;
            cache.TaxResponseAttributes = JsonConvert.SerializeObject(tax);

            if (data.tjc != null) //update the existing entry
            {
                cache.ID = data.tjc.ID;
                _context.TaxJarCache.Add(cache);
                _context.Entry(cache).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else //add a new entry
            {
                _context.TaxJarCache.Add(cache);
            }
            await _context.SaveChangesAsync();
            /******************************END CACHE RESULTS******************************/

            return tax;
        }

        //TODO: may need to send in a paymentMethodID here to update with?
        public async Task<PaymentIntent> CreatePaymentIntent(string stripeCustomerID, TaxResponseAttributes tax, SubscriptionType subscription)
        {            
            StripeSubscriptions details = _stripeConfig.Subscriptions.Where(s => s.Name == subscription.GetDescription()).FirstOrDefault();
            decimal subscriptionCost = decimal.Parse(details.Cost.Replace("$", ""));

            if (tax != null && tax.TaxableAmount != subscriptionCost) throw new ApplicationException("The proposed tax does not correlate with this subscription."); //sanity check to ensure the chosen selection is being taxed appropriately.

            StripeConfiguration.ApiKey = _stripeConfig.SecretKey;

            decimal chargeAmount = subscriptionCost;
            if (tax != null)
            {
                chargeAmount = chargeAmount * (1M + tax.Rate);
            }

            PaymentIntentCreateOptions options = new PaymentIntentCreateOptions();
            options.Amount = (long)(chargeAmount * 100M); //multiply by 100 to get the appropriate Stripe amount since Stripe works with the lowest denomination of the currency...
            options.Currency = "usd";
            options.Customer = stripeCustomerID;
            options.StatementDescriptor = "WorkByrd Subscription"; //22 characters max...
            options.Description = $"WorkByrd - {details.Name} Subscription";

            PaymentIntentService service = new PaymentIntentService();
            PaymentIntent paymentIntent = await service.CreateAsync(options);

            //TODO - throw exception here if certain data is not present? Does service.CreateAsync throw an exception?

            return paymentIntent;
        }

        //TODO: may need to send in a paymentMethodID here to update with?
        public async Task<PaymentIntent> UpdatePaymentIntent(string paymentIntentID, TaxResponseAttributes tax, SubscriptionType subscription)
        {
            StripeSubscriptions details = _stripeConfig.Subscriptions.Where(s => s.Name == subscription.GetDescription()).FirstOrDefault();
            decimal subscriptionCost = decimal.Parse(details.Cost.Replace("$", ""));

            if (tax != null && tax.TaxableAmount != subscriptionCost) throw new ApplicationException("The proposed tax does not correlate with this subscription."); //sanity check to ensure the chosen selection is being taxed appropriately.

            StripeConfiguration.ApiKey = _stripeConfig.SecretKey;

            decimal chargeAmount = subscriptionCost;
            if (tax != null)
            {
                chargeAmount = chargeAmount * (1M + tax.Rate);
            }

            PaymentIntentService service = new PaymentIntentService();
            var options = new PaymentIntentUpdateOptions();
            options.Amount = (long)(chargeAmount * 100M); //multiply by 100 to get the appropriate Stripe amount since Stripe works with the lowest denomination of the currency...;
            options.StatementDescriptor = "WorkByrd Subscription"; //22 characters max...
            options.Description = $"WorkByrd - {details.Name} Subscription";
            PaymentIntent paymentIntent = await service.UpdateAsync(paymentIntentID, options);

            //TODO - throw exception here if certain data is not present? Does service.CreateAsync throw an exception?

            return paymentIntent;
        }

        private void RecalculateTaxResponse(ref TaxResponseAttributes tax, StripeSubscriptions subscription)
        {
            if (tax == null) return;
            decimal subscriptionCost = decimal.Parse(subscription.Cost.Replace("$", ""));

            if (tax.TaxableAmount != subscriptionCost) //The tax rates are correct but the totalled amounts are different because we are looking at a different prescription
            {
                if (tax.Breakdown != null)
                {
                    if(tax.Breakdown.CityTaxRate != 0M)
                    {
                        tax.Breakdown.CityTaxableAmount = subscriptionCost;
                        tax.Breakdown.CityTaxCollectable = decimal.Round(subscriptionCost * tax.Breakdown.CityTaxRate, 2, MidpointRounding.AwayFromZero);
                        //tax.Breakdown.CityTaxRate;
                    }
                    if(tax.Breakdown.CountryTaxRate != 0M)
                    {
                        tax.Breakdown.CountryTaxableAmount = subscriptionCost;
                        tax.Breakdown.CountryTaxCollectable = decimal.Round(subscriptionCost * tax.Breakdown.CountryTaxRate, 2, MidpointRounding.AwayFromZero);
                        //tax.Breakdown.CountryTaxRate;
                    }
                    if (tax.Breakdown.CountyTaxRate != 0M)
                    {
                        tax.Breakdown.CountyTaxableAmount = subscriptionCost;
                        tax.Breakdown.CountyTaxCollectable = decimal.Round(subscriptionCost * tax.Breakdown.CountyTaxRate, 2, MidpointRounding.AwayFromZero);
                        //tax.Breakdown.CountyTaxRate;
                    }
                    if(tax.Breakdown.GSTTaxRate != 0M)
                    {
                        tax.Breakdown.GST = decimal.Round(subscriptionCost * tax.Breakdown.GSTTaxRate, 2, MidpointRounding.AwayFromZero);
                        tax.Breakdown.GSTTaxableAmount = subscriptionCost;
                        //tax.Breakdown.GSTTaxRate;
                    }
                    if(tax.Breakdown.PSTTaxRate != 0M)
                    {
                        tax.Breakdown.PST = decimal.Round(subscriptionCost * tax.Breakdown.PSTTaxRate, 2, MidpointRounding.AwayFromZero);
                        tax.Breakdown.PSTTaxableAmount = subscriptionCost;
                        //tax.Breakdown.PSTTaxRate;
                    }
                    if(tax.Breakdown.QSTTaxRate != 0M)
                    {
                        tax.Breakdown.QST = decimal.Round(subscriptionCost * tax.Breakdown.QSTTaxRate, 2, MidpointRounding.AwayFromZero);
                        tax.Breakdown.QSTTaxableAmount = subscriptionCost;
                        //tax.Breakdown.QSTTaxRate;
                    }
                    if(tax.Breakdown.SpecialDistrictTaxRate != 0M)
                    {
                        tax.Breakdown.SpecialDistrictTaxableAmount = subscriptionCost;
                        tax.Breakdown.SpecialDistrictTaxCollectable = decimal.Round(subscriptionCost * tax.Breakdown.SpecialDistrictTaxRate, 2, MidpointRounding.AwayFromZero);
                        //tax.Breakdown.SpecialDistrictTaxRate;
                    }
                    if(tax.Breakdown.StateTaxRate != 0M)
                    {
                        tax.Breakdown.StateTaxableAmount = subscriptionCost;
                        tax.Breakdown.StateTaxCollectable = decimal.Round(subscriptionCost * tax.Breakdown.StateTaxRate, 2, MidpointRounding.AwayFromZero);
                        //tax.Breakdown.StateTaxRate;
                    }
                    //tax.Breakdown.Shipping;
                    //tax.Breakdown.CombinedTaxRate;
                    tax.Breakdown.TaxableAmount = subscriptionCost;
                    tax.Breakdown.TaxCollectable = decimal.Round(subscriptionCost * tax.Breakdown.CombinedTaxRate, 2, MidpointRounding.AwayFromZero);

                    if (tax.Breakdown.LineItems != null & tax.Breakdown.LineItems.Count > 0)
                    {
                        foreach (TaxBreakdownLineItem item in tax.Breakdown.LineItems)
                        {
                            item.CityAmount = tax.Breakdown.CityTaxCollectable;
                            item.CityTaxableAmount = tax.Breakdown.CityTaxableAmount;
                            //item.CityTaxRate;
                            //item.CombinedTaxRate;
                            item.CountryTaxableAmount = tax.Breakdown.CountryTaxableAmount;
                            item.CountryTaxCollectable = tax.Breakdown.CountryTaxCollectable;
                            //item.CountryTaxRate;
                            item.CountyAmount = tax.Breakdown.CountyTaxCollectable;
                            item.CountyTaxableAmount = tax.Breakdown.CountyTaxableAmount;
                            //item.CountyTaxRate;
                            item.GST = tax.Breakdown.GST;
                            item.GSTTaxableAmount = tax.Breakdown.GSTTaxableAmount;
                            //item.GSTTaxRate;
                            //item.Id;
                            item.PST = tax.Breakdown.PST;
                            item.PSTTaxableAmount = tax.Breakdown.PSTTaxableAmount;
                            //item.PSTTaxRate;
                            item.QST = tax.Breakdown.QST;
                            item.QSTTaxableAmount = tax.Breakdown.QSTTaxableAmount;
                            //item.QSTTaxRate;
                            item.SpecialDistrictAmount = tax.Breakdown.SpecialDistrictTaxCollectable;
                            item.SpecialDistrictTaxableAmount = tax.Breakdown.SpecialDistrictTaxableAmount;
                            //item.SpecialTaxRate;
                            item.StateAmount = tax.Breakdown.StateTaxCollectable;
                            //item.StateSalesTaxRate;
                            item.StateTaxableAmount = tax.Breakdown.StateTaxableAmount;
                            item.TaxableAmount = tax.Breakdown.TaxableAmount;
                            item.TaxCollectable = tax.Breakdown.TaxCollectable;
                        }
                    }
                }

                //tax.ExemptionType;
                //tax.FreightTaxable;
                //tax.HasNexus;
                //tax.Jurisdictions.City;
                //tax.Jurisdictions.Country;
                //tax.Jurisdictions.County;
                //tax.Jurisdictions.State;
                //tax.Rate;
                //tax.Shipping;
                //tax.TaxSource;
                tax.OrderTotalAmount = tax.TaxableAmount + tax.Shipping;
                tax.TaxableAmount = subscriptionCost;
                tax.AmountToCollect = decimal.Round(subscriptionCost * tax.Rate, 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}
