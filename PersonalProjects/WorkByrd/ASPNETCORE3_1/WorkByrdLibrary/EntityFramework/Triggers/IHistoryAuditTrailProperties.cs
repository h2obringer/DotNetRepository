using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Triggers
{
    public interface IHistoryAuditTrailProperties
    {
        string LastModifiedByUserID { get; set; }
        DateTime LastModifiedDateTimeUTC { get; set; }
        HistoryAuditAction HistoryAction { get; set; }
    }
}
