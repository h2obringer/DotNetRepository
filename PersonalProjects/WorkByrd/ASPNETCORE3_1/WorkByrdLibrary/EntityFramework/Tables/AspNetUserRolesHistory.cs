using Microsoft.AspNetCore.Identity;
using System;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class AspNetUserRolesHistory
    {
        public AspNetUserRolesHistory()
        {
        }

        public AspNetUserRolesHistory(IdentityUserRole<string> userRole, string currentUserID, HistoryAuditAction action)
        {
            this.ID = Guid.NewGuid().ToString();
            this.AspNetUserRoles_UserID = userRole.UserId;
            this.AspNetUserRoles_RoleID = userRole.RoleId;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string ID { get; set; }
        public string AspNetUserRoles_UserID { get; set; }
        public string AspNetUserRoles_RoleID { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
