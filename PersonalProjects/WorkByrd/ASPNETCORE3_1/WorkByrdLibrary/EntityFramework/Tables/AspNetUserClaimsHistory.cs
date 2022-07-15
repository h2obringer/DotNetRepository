using Microsoft.AspNetCore.Identity;
using System;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class AspNetUserClaimsHistory : IHistoryAuditTrailProperties
    {
        public AspNetUserClaimsHistory()
        {
        }

        public AspNetUserClaimsHistory(IdentityUserClaim<string> claim, string currentUserID, HistoryAuditAction action)
        {
            this.Id = Guid.NewGuid().ToString();
            this.AspNetUserClaims_ID = claim.Id;
            this.UserID = claim.UserId;
            this.ClaimType = claim.ClaimType;
            this.ClaimValue = claim.ClaimValue;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string Id { get; set; }
        public int AspNetUserClaims_ID { get; set; }
        public string UserID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
