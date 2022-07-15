namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class StateProvince
    {
        public StateProvince()
        {
            //Companies = new List<Company>();
        }

        #region public properties
        public long ID { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public long CountryID { get; set; }

        public bool HasTaxNexus { get; set; }
        #endregion

        //#region navigation properties
        //[ForeignKey("CountryID")]
        //public Country Country { get; set; }

        //public ICollection<Company> Companies { get; set; }
        //#endregion
    }
}