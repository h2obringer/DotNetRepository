using System;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class StripePaymentMethod
    {
        public StripePaymentMethod()
        {
            ID = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
        }

        public StripePaymentMethod(Stripe.PaymentMethod method, string companyID)
            : this()
        {
            CompanyID = companyID;
            StripeID = method.Id; //pm_1G9Mz62eZvKYlo2COZiUBShP
            Type = method.Type; //"card"
            BillingEmail = method.BillingDetails.Email;
            BillingZipCode = method.BillingDetails.Address.PostalCode;
            CardBrand = method.Card.Brand; //"visa"
            CardExpirationMonth = method.Card.ExpMonth;
            CardExpirationYear = method.Card.ExpYear;
            CardFundingType = method.Card.Funding; //"credit"
            CardLast4 = method.Card.Last4;
            CardCountry = method.Card.Country; //"US"
        }

        #region public properties
        public string ID { get; set; }
        public string StripeID { get; set; }
        public string CompanyID { get; set; }
        public string Type { get; set; } //card
        public string BillingEmail { get; set; }
        public string BillingZipCode { get; set; }
        public string CardBrand { get; set; } //visa
        public long CardExpirationMonth { get; set; }
        public long CardExpirationYear { get; set; }
        public string CardFundingType { get; set; } //debit or credit
        public string CardLast4 { get; set; }
        public string CardCountry { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}