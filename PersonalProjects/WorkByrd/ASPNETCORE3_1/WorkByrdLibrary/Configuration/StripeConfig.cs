using System;
using System.Collections.Generic;
using WorkByrdLibrary.Extensions;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.Configuration
{
    //AppSettings:

    //...
    //"Stripe": {
    //  "PublishableKey": "pk_...",
    //  "SecretKey": "sk_...",
    //  "Subscriptions": {
    //      "Apprentice": "plan_...",
    //      "Craftsman": "plan_...",
    //      "MasterCraftsman": "plan_..."
    //  }
    //},
    //...

    public class StripeConfig
    {
        public string PublishableKey { get; set; }
        public string SecretKey { get; set; }
        public List<StripeSubscriptions> Subscriptions { get; set; }

        public void Validate()
        {
            HashSet<SubscriptionType> types = new HashSet<SubscriptionType>();
            types.Add(SubscriptionType.NA);

            foreach (StripeSubscriptions x in Subscriptions)
            {
                SubscriptionType subscriptionType = x.Name.ToEnum<SubscriptionType>();

                if (IsValidEntry(x))
                {
                    types.Add(x.Name.ToEnum<SubscriptionType>());
                }
            }

            if (!types.Contains(SubscriptionType.Apprentice))
            {
                throw new ArgumentException("Apprentice subscription settings are wrong or incomplete in appSettings.json.");
            }
            if (!types.Contains(SubscriptionType.Craftsman))
            {
                throw new ArgumentException("Craftsman subscription settings are wrong or incomplete in appSettings.json.");
            }
            if (!types.Contains(SubscriptionType.MasterCraftsman))
            {
                throw new ArgumentException("MasterCraftsman subscription settings are wrong or incomplete in appSettings.json.");
            }

            return;
        }

        private bool IsValidEntry(StripeSubscriptions stripeSubscription)
        {
            if(stripeSubscription == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(stripeSubscription.Name))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(stripeSubscription.Cost))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(stripeSubscription.StripeID))
            {
                return false;
            }

            return true;
        }
    }

    public class StripeSubscriptions
    {
        public string Name { get; set; }
        public string StripeID { get; set; }
        public string Cost { get; set; }
        public string TaxJarProductTaxCode { get; set; } //TODO
    }
}
