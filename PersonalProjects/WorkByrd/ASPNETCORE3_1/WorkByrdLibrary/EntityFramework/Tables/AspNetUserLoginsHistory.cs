using Microsoft.AspNetCore.Identity;
using System;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class AspNetUserLoginsHistory
    {
        public AspNetUserLoginsHistory()
        {
        }

        public AspNetUserLoginsHistory(IdentityUserLogin<string> login, string currentUserID, HistoryAuditAction action)
        {
            this.Id = Guid.NewGuid().ToString();
            this.LoginProvider = login.LoginProvider;
            this.ProviderKey = login.ProviderKey;
            this.ProviderDisplayName = login.ProviderDisplayName;
            this.UserID = login.UserId;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserID { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
