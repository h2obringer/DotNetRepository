namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class TimeZone
    {
        public TimeZone()
        {
            //Companies = new List<Company>();
        }

        #region public properties
        public long ID { get; set; }

        public string Abbreviation { get; set; }

        public string Zone { get; set; }

        public string UtcOffset { get; set; }

        public bool IsActive { get; set; }

        public string ChangedByUserID { get; set; }
        #endregion

        //#region navigation properties
        //public ICollection<Company> Companies { get; set; }
        //#endregion
    }
}