using System;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class Company
    {
        public Company()
        {
            ID = Guid.NewGuid().ToString();
            //this.CompanyEmployees = new List<CompanyEmployee>();
        }

        #region regular properties
        public string ID { get; set; }

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

        public string BusinessHours { get; set; } //TODO - use custom function here to translate between string and structured data

        public long TimeZoneID { get; set; }
        public string StripeCustomerID { get; set; }
        public string StripeCreateCustomerDetails { get; set; }

        public string SubscriptionType { get; set; }

        public DateTime SubscriptionExpirationDateUTC { get; set; }
        #endregion

        //#region navigation properties
        //[ForeignKey("StateProvinceID")]
        //public StateProvince StateProvince;

        //[ForeignKey("TimeZoneID")]
        //public TimeZone TimeZone;

        ////public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; }
        //#endregion
    }
}