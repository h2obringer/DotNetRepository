using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class StripePaymentMethodHistory : IHistoryAuditTrailProperties
    {
        public StripePaymentMethodHistory()
        {
        }

        public StripePaymentMethodHistory(StripePaymentMethod method, string currentUserID, HistoryAuditAction action)
        {
            this.ID = Guid.NewGuid().ToString();
            this.PaymentMethodID = method.ID;
            this.StripeID = method.StripeID;
            this.CompanyID = method.CompanyID;
            this.Type = method.Type;
            this.BillingEmail = method.BillingEmail;
            this.BillingZipCode = method.BillingZipCode;
            this.CardBrand = method.CardBrand;
            this.CardExpirationMonth = method.CardExpirationMonth;
            this.CardExpirationYear = method.CardExpirationYear;
            this.CardFundingType = method.CardFundingType;
            this.CardLast4 = method.CardLast4;
            this.CardCountry = method.CardCountry;
            this.CreatedDate = method.CreatedDate;
            this.IsActive = method.IsActive;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string ID { get; set; }
        public string PaymentMethodID { get; set; }
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
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
