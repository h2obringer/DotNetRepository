using Microsoft.AspNetCore.Identity;
using System;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class AspNetRolesHistory : IHistoryAuditTrailProperties
    {
        public AspNetRolesHistory()
        {
        }

        public AspNetRolesHistory(IdentityRole<string> role, string currentUserID, HistoryAuditAction action)
        {
            this.Id = Guid.NewGuid().ToString();
            this.AspNetRoles_ID = role.Id;
            this.ConcurrencyStamp = role.ConcurrencyStamp;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string Id { get; set; }
        public string AspNetRoles_ID { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; private set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    };
}
