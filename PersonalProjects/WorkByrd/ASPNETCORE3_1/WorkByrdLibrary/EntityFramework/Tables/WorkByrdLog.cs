using System;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class WorkByrdLog
    {
        public WorkByrdLog()
        {
            ID = Guid.NewGuid().ToString();
            CreatedDateUTC = DateTime.UtcNow;
        }

        public string ID { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string InnerException { get; set; }

        public DateTime CreatedDateUTC { get; set; }

        public EntryPoint EntryPoint { get; set; }

        public string Location { get; set; }

        public LogLevel LogLevel { get; set; }

        public string UserID { get; set; }
    }
}
