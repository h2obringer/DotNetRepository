using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class Country
    {
        public Country()
        {
            //this.StateProvinces = new List<StateProvince>();
        }

        #region public properties
        public long ID { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public long ContinentID { get; set; }

        public bool IsActive { get; set; }

        #endregion

        //#region navigation properties
        //public ICollection<StateProvince> StateProvinces { get; set; }
        //#endregion
    }
}