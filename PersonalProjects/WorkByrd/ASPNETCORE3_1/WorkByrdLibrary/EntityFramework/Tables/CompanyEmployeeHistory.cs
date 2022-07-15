using System;
using WorkByrdLibrary.EntityFramework.Triggers;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class CompanyEmployeeHistory : IHistoryAuditTrailProperties
    {
        public CompanyEmployeeHistory()
        {
        }

        public CompanyEmployeeHistory(CompanyEmployee employee, string currentUserID, HistoryAuditAction action)
        {
            this.ID = Guid.NewGuid().ToString();
            this.CompanyEmployee_ID = employee.ID;
            this.CompanyID = employee.CompanyID;
            this.UserID = employee.UserID;
            this.LastModifiedByUserID = currentUserID;
            this.LastModifiedDateTimeUTC = DateTime.UtcNow;
            this.HistoryAction = action;
        }

        public string ID { get; set; }
        public string CompanyEmployee_ID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string LastModifiedByUserID { get; set; }
        public DateTime LastModifiedDateTimeUTC { get; set; }
        public HistoryAuditAction HistoryAction { get; set; }
    }
}
