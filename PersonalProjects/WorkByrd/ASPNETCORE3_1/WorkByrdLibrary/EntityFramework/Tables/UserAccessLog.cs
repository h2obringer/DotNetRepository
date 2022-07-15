using System;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class UserAccessLog
    {
        public UserAccessLog(string userName, UserAccessAction action, EntryPoint entryPoint)
        {
            ID = Guid.NewGuid().ToString();
            UserName = userName;
            Action = action;
            EntryPoint = entryPoint;
            TimeStampUTC = DateTime.UtcNow;
        }

        public string ID { get; set; }

        public string UserName { get; set; }

        public UserAccessAction Action { get; set; }

        public EntryPoint EntryPoint { get; set; }

        public DateTime TimeStampUTC { get; set; }
        //TODO possibly log user IP address, etc...
    }
}
