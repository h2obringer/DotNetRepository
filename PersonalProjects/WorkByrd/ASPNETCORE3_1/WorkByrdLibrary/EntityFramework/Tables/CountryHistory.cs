using System;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class CountryHistory : IHistoryAuditTrailProperties
    {
        public CountryHistory()
        {
        }

        public CountryHistory(Country country, string currentUserID, HistoryAuditAction action)
        {
            this.ID = Guid.NewGuid().ToString();
            this.Country_ID = country.ID;
            this.Name = country.Name;
            this.Abbreviation = country.Abbreviation;
            this.ContinentID = country.ContinentID;
            this.IsActive = country.IsActive;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string ID { get; set; }
        public long Country_ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public long ContinentID { get; set; }
        public bool IsActive { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
