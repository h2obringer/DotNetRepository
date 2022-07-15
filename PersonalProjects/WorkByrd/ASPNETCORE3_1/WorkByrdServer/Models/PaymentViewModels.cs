using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkByrdLibrary.Configuration;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdServer.Models
{
    public class SubscriptionViewModel
    {
        //has a list of subscriptions with names, costs, product tax codes...
        public StripeConfig Config { get; set; }

        //Company details for payment_method.billing_details (when submitting payment to Stripe)

        //other information for saving the customer details like Name, email, etc.
        
        //public List<StripePaymentMethod> paymentMethodsOnRecord; // TODO

        public string StripeCustomerID { get; set; } //can get this in the AJAX method when creating the payment intent...
    }
}
