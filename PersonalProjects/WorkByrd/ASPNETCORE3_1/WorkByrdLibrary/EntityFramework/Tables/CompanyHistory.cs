using System;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class CompanyHistory : IHistoryAuditTrailProperties
    {
        public CompanyHistory()
        {
        }

        public CompanyHistory(Company company, string currentUserID, HistoryAuditAction action)
        {
            this.ID = Guid.NewGuid().ToString();
            this.CompanyID = company.ID;
            this.Name = company.Name;
            this.PhoneNumber = company.PhoneNumber;
            this.Email = company.Email;
            this.IsEmailConfirmed = company.IsEmailConfirmed;
            this.Address1 = company.Address1;
            this.Address2 = company.Address2;
            this.Address3 = company.Address3;
            this.City = company.City;
            this.StateProvinceID = company.StateProvinceID;
            this.ZipCode = company.ZipCode;
            this.URL = company.URL;
            this.BusinessHours = company.BusinessHours;
            this.TimeZoneID = company.TimeZoneID;
            this.SubscriptionType = company.SubscriptionType;
            this.SubscriptionExpirationDateUTC = company.SubscriptionExpirationDateUTC;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public long StateProvinceID { get; set; }
        public string ZipCode { get; set; }
        public string URL { get; set; }
        public string BusinessHours { get; set; }
        public long TimeZoneID { get; set; }
        public string StripeCustomerID { get; set; }
        public string StripeCreateCustomerDetails { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime SubscriptionExpirationDateUTC { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
