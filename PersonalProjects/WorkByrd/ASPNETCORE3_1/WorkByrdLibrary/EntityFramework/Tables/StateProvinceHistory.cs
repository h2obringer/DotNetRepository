using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class StateProvinceHistory : IHistoryAuditTrailProperties
    {
        public StateProvinceHistory(){}

        public StateProvinceHistory(StateProvince state, string currentUserID, HistoryAuditAction action)
        {
            this.ID = Guid.NewGuid().ToString();
            this.StateProvince_ID = state.ID;
            this.Name = state.Name;
            this.Abbreviation = state.Abbreviation;
            this.CountryID = state.CountryID;
            this.HasTaxNexus = state.HasTaxNexus;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string ID { get; set; }
        public long StateProvince_ID { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public long CountryID { get; set; }

        public bool HasTaxNexus { get; set; }

        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
