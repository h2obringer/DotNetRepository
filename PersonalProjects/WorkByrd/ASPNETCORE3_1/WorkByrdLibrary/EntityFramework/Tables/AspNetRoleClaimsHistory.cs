using Microsoft.AspNetCore.Identity;
using System;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class AspNetRoleClaimsHistory : IHistoryAuditTrailProperties
    {
        public AspNetRoleClaimsHistory()
        {
        }

        public AspNetRoleClaimsHistory(IdentityRoleClaim<string> claim, string currentUserID, HistoryAuditAction action)
        {
            this.Id = Guid.NewGuid().ToString();
            this.AspNetRoleClaims_ID = claim.Id;
            this.RoleID = claim.RoleId;
            this.ClaimType = claim.ClaimType;
            this.ClaimValue = claim.ClaimValue;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string Id { get; set; }
        public int AspNetRoleClaims_ID { get; set; }
        public string RoleID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
