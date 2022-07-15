using System;
using System.Collections.Generic;
using System.Text;

namespace WorkByrdLibrary.Configuration
{
    //AppSettings:

    //...
    //"EmailSettings": {
    //  "ServiceHost": "smtp.gmail.com",
    //  "ServicePort": "587",
    //  "EmailAddress": "",
    //  "EmailAccessKey": ""
    //},
    //...

    public class EmailConfig
    {
        public string ServiceHost { get; set; }
        public int ServicePort { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAccessKey { get; set; }
    }
}
