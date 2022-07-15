using Microsoft.AspNetCore.Identity;
using System;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class AspNetUserTokensHistory
    {
        public AspNetUserTokensHistory()
        {
        }

        public AspNetUserTokensHistory(IdentityUserToken<string> token, string currentUserID, HistoryAuditAction action)
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserID = token.UserId;
            this.LoginProvider = token.LoginProvider;
            this.Name = token.Name;
            this.Value = token.Value;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string Id { get; set; }
        public string UserID { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
