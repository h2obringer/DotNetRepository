using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class ApplicationUserHistory : IHistoryAuditTrailProperties
    {
        public ApplicationUserHistory()
        {
        }

        public ApplicationUserHistory(ApplicationUser user, string currentUserID, HistoryAuditAction action)
        {
            this.Id = Guid.NewGuid().ToString();
            this.AccessFailedCount = user.AccessFailedCount;
            this.ConcurrencyStamp = user.ConcurrencyStamp;
            this.Email = user.Email;
            this.EmailConfirmed = user.EmailConfirmed;
            this.FirstName = user.FirstName;
            this.AspNetUsers_ID = user.Id;
            this.LastName = user.LastName;
            this.LockoutEnabled = user.LockoutEnabled;
            this.LockoutEnd = user.LockoutEnd;
            this.NormalizedEmail = user.NormalizedEmail;
            this.NormalizedUserName = user.NormalizedUserName;
            this.PasswordHash = user.PasswordHash;
            this.PhoneNumber = user.PhoneNumber;
            this.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            this.SecurityStamp = user.SecurityStamp;
            this.TwoFactorEnabled = user.TwoFactorEnabled;
            this.UserName = user.UserName;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string Id { get; set; }
        public string AspNetUsers_ID { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string NormalizedUserName { get; private set; }
        public string Email { get; private set; }
        public string NormalizedEmail { get; private set; }
        public bool EmailConfirmed { get; private set; }
        public string PasswordHash { get; private set; }
        public string SecurityStamp { get; private set; }
        public string ConcurrencyStamp { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool PhoneNumberConfirmed { get; private set; }
        public bool TwoFactorEnabled { get; private set; }
        public DateTimeOffset? LockoutEnd { get; private set; }
        public bool LockoutEnabled { get; private set; }
        public int AccessFailedCount { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    };
}
