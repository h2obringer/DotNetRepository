using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WorkByrdLibrary.EntityFramework.Tables
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ApplicationUser() : base()
        {

            //this.CompanyEmployees = new List<CompanyEmployee>();
        }

        public ApplicationUser(string userName)
            : this()
        {
            UserName = userName;
            Email = userName;
        }

        //public ICollection<CompanyEmployee> CompanyEmployees { get; set; }
    }
}
