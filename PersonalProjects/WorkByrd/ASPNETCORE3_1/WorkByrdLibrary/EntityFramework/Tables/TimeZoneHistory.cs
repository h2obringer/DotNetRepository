using System;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class TimeZoneHistory : IHistoryAuditTrailProperties
    {
        public TimeZoneHistory()
        {
        }

        public TimeZoneHistory(Tables.TimeZone zone, string currentUserID, HistoryAuditAction action)
        {
            this.ID = Guid.NewGuid().ToString();
            this.TimeZone_ID = zone.ID;
            this.Abbreviation = zone.Abbreviation;
            this.Zone = zone.Zone;
            this.UtcOffset = zone.UtcOffset;
            this.IsActive = zone.IsActive;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string ID { get; set; }
        public long TimeZone_ID { get; set; }
        public string Abbreviation { get; set; }
        public string Zone { get; set; }
        public string UtcOffset { get; set; }
        public bool IsActive { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
