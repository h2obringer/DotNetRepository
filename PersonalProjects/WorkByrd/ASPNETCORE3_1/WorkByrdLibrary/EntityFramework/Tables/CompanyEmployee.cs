using System;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class CompanyEmployee
    {
        public CompanyEmployee()
        {
            ID = Guid.NewGuid().ToString();
        }

        #region regular properties
        public string ID { get; set; }

        public string CompanyID { get; set; }

        public string UserID { get; set; }
        #endregion

        #region navigation properties
        //[ForeignKey("UserID")]
        //      public ApplicationUser User;

        //      [ForeignKey("CompanyID")]
        //      public Company Company;
        #endregion
    }
}
