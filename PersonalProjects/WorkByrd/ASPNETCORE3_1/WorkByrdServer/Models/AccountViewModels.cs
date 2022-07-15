using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkByrdLibrary.Configuration;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.Utils;

namespace WorkByrdServer.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        //See Startup.cs:RegisterIdentitySystemDI() if changes are made here...
        //See AccountController:RegisterUser if changes are made here...
        //See AccountViewModels.cs:RegisterUserViewModel and ResetPasswordViewModel if changes are made here...
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Cell Phone #")]
        public string PhoneNumber { get; set; }

        //See Startup.cs:RegisterIdentitySystemDI() if changes are made here...
        //See AccountController:RegisterUser if changes are made here...
        //See AccountViewModels.cs:RegisterUserViewModel and ResetPasswordViewModel if changes are made here...
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class RegisterCompanyViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string CompanyName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string CompanyPhoneNumber { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string CompanyEmail { get; set; }

        [Required]
        [Display(Name = "Country")]
        public long CountryID { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string CompanyAddress1 { get; set; }

        [DataType(DataType.Text)]
        public string CompanyAddress2 { get; set; }

        [DataType(DataType.Text)]
        public string CompanyAddress3 { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string CompanyCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public long CompanyStateProvinceID { get; set; }
        public IEnumerable<SelectListItem> StateProvinceList { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string CompanyZipCode { get; set; }

        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "URL / Website")]
        [DataType(DataType.Url)]
        public string CompanyURL { get; set; }

        [Display(Name = "Hours of Operation")]
        [DataType(DataType.Text)]
        public string CompanyBusinessHours { get; set; } //TODO - use custom function here to translate between string and structured data

        [Required]
        [Display(Name = "Time Zone")]
        public long CompanyTimeZoneID { get; set; }
        public IEnumerable<SelectListItem> TimeZoneList { get; set; }

        [Required]
        [Display(Name = "User Account")]
        public string UserID { get; set; }

        public string UserEmail { get; set; }
        public string UserPhone { get; set; }

        public void SetDropDownData(ApplicationDbContext context)
        {
            List<SelectListItem> CountryList = context.Countries.AsNoTracking()
                    .Where(c => c.IsActive == true)
                    .OrderBy(c => c.Name)
                    .Select(c =>
                    new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name,
                        Selected = (this.CountryID > 0 && (c.ID == this.CountryID) ? true : (c.Name == "United States of America" ? true : false))
                    }).ToList();

            long selectedcountryid = DataUtils.GetLong(CountryList.Where(c => c.Selected == true).FirstOrDefault().Value);

            this.CountryList = CountryList;

            //model.StateProvinceList = new List<SelectListItem>(); //leave empty for now until the user selects a country
            List<SelectListItem> StateProvinceList = context.StateProvinces.AsNoTracking()
                .Where(s => s.CountryID == selectedcountryid)
                .OrderBy(s => s.Name)
                .Select(s =>
                new SelectListItem
                {
                    Value = s.ID.ToString(),
                    Text = s.Name,
                    Selected = s.ID == this.CompanyStateProvinceID
                }).ToList();
            StateProvinceList.Add(new SelectListItem { Value = "", Text = "", Selected = this.CompanyStateProvinceID == 0 }); //default blank entry
            this.StateProvinceList = StateProvinceList;

            List<SelectListItem> TimeZoneList = context.TimeZones.AsNoTracking()
                .Where(t => t.IsActive == true)
                .OrderBy(t => t.Zone)
                .Select(t =>
                new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Zone,
                    Selected = this.CompanyTimeZoneID == t.ID
                }).ToList();
            TimeZoneList.Add(new SelectListItem { Value = "", Text = "", Selected = this.CompanyTimeZoneID == 0 }); //default blank entry
            this.TimeZoneList = TimeZoneList;
        }
    }

    public class RegisterUserEmailViewModel
    {
        [Required]
        [Display(Name = "User Account")]
        public string UserID { get; set; }

        public string Email { get; set; }
    }

    public class RegisterCompanyEmailViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Company Account")]
        public string CompanyID { get; set; }

        [Required]
        [Display(Name = "User Account")]
        public string UserID { get; set; }
    }
}
