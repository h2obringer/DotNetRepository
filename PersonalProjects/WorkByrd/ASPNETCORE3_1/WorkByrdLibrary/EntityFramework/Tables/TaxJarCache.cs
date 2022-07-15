using System;
using System.Collections.Generic;
using System.Text;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class TaxJarCache
    {
        public TaxJarCache()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; set; }
        public string Company_ID { get; set; }
        public string TaxResponseAttributes { get; set; }
        public DateTime LastUpdatedDateUTC { get; set; }
    }
}
