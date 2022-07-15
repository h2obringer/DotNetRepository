using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkByrdLibrary.Attributes;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WorkByrdServer.Models
{
    public class CountryAdmin
    {
        public CountryAdmin()
        {
        }

        public CountryAdmin(Country country)
        {
            Abbreviation = country.Abbreviation;
            //ContinentID = country.ContinentID;
            ID = country.ID;
            IsActive = country.IsActive;
            Name = country.Name;
            IsChanged = false;
        }

        [ColumnHidden]
        [ColumnEditable(ColumnEditOption.Text)]
        public long ID { get; set; }

        [ColumnEditable(ColumnEditOption.Text)]
        public string Name { get; set; }

        [ColumnEditable(ColumnEditOption.Text)]
        public string Abbreviation { get; set; }

        [ColumnLabel("Active")]
        [ColumnEditable(ColumnEditOption.Checkbox)]
        public bool IsActive { get; set; }
        
        [ColumnChangeTracker]
        [ColumnHidden]
        public bool IsChanged { get; set; }

        //public long ContinentID { get; set; }

        public Country GetCountry()
        {
            return new Country
            {
                ID = this.ID,
                Abbreviation = this.Abbreviation,
                //ContinentID = this.ContinentID,
                IsActive = this.IsActive,
                Name = this.Name
            };
        }
    }

    public class StateProvinceAdmin
    {
        public StateProvinceAdmin() { }

        public StateProvinceAdmin(StateProvince sp)
        {
            ID = sp.ID;
            Name = sp.Name;
            Abbreviation = sp.Abbreviation;
            HasTaxNexus = sp.HasTaxNexus;
        }

        [ColumnHidden]
        [ColumnEditable(ColumnEditOption.Text)]
        public long ID { get; set; }
        public string Name { get; set; }

        [ColumnEditable(ColumnEditOption.Text)]
        public string Abbreviation { get; set; }

        [ColumnLabel("Has Tax Nexus")]
        [ColumnEditable(ColumnEditOption.Checkbox)]
        public bool HasTaxNexus { get; set; }
        
        [ColumnChangeTracker]
        [ColumnHidden]
        public bool IsChanged { get; set; }

        public StateProvince GetStateProvince()
        {
            return new StateProvince
            {
                ID = this.ID,
                Name = this.Name,
                Abbreviation = this.Abbreviation,
                HasTaxNexus = this.HasTaxNexus
            };
        }
    }

    public class TimeZoneAdmin
    {
        public TimeZoneAdmin() { }

        public TimeZoneAdmin(WorkByrdLibrary.EntityFramework.Tables.TimeZone zone)
        {
            ID = zone.ID;
            Abbreviation = zone.Abbreviation;
            Zone = zone.Zone;
            UtcOffset = zone.UtcOffset;
            IsActive = zone.IsActive;
        }

        [ColumnHidden]
        [ColumnEditable(ColumnEditOption.Text)]
        public long ID { get; set; }

        [ColumnEditable(ColumnEditOption.Text)]
        public string Abbreviation { get; set; }

        [ColumnLabel("Time Zone")]
        [ColumnEditable(ColumnEditOption.Text)]
        public string Zone { get; set; }

        [ColumnLabel("UTC Offset")]
        [ColumnEditable(ColumnEditOption.Text)]
        public string UtcOffset { get; set; }

        [ColumnLabel("Active")]
        [ColumnEditable(ColumnEditOption.Checkbox)]
        public bool IsActive { get; set; }

        [ColumnChangeTracker]
        [ColumnHidden]
        public bool IsChanged { get; set; }

        public WorkByrdLibrary.EntityFramework.Tables.TimeZone GetTimeZone()
        {
            return new WorkByrdLibrary.EntityFramework.Tables.TimeZone
            {
                ID = this.ID,
                Abbreviation = this.Abbreviation,
                Zone = this.Zone,
                UtcOffset = this.UtcOffset,
                IsActive = this.IsActive
            };
        }
    }

    public class CompanyAdmin
    {
        public CompanyAdmin() { }

        public CompanyAdmin(Company company)
        {
            ID = company.ID;
            Name = company.Name;
            SubscriptionType = company.SubscriptionType;
        }
        
        public string Name { get; set; }

        [ColumnPk]
        [ModalButton("Save Changes", ModalButtonType.SuccessGreen, warningPrompt: "You are about to save changes for the entry in the system. Are you sure you want to proceed?")]
        //[ModalButton("Delete", ModalButtonType.DangerRed, warningPrompt: "You are about to delete this entry from the system. This will delete all data belonging to this company to include employee user accounts and more. Are you sure you want to proceed?")]
        [ColumnDynamicModal("CompanyDetails", "Company Details", ModalSize.Large, buttonType: ModalButtonType.PrimaryOutlineBlue)]
        public string ID { get; set; }

        [ColumnLabel("Users")]
        [ColumnLink("CompanyUsers", "Users", buttonType: ModalButtonType.InfoOutlineTurquoise)]
        public string UsersLink { get; set; }

        public string SubscriptionType { get; set; }

        //public DateTime SubscriptionExpirationDateUTC { get; set; }

        public Company GetCompany()
        {
            return new Company()
            {
                ID = this.ID,
                Name = this.Name,
                SubscriptionType = this.SubscriptionType
            };
        }
    }

    public class CompanyDetails
    {
        public CompanyDetails() { }
        public CompanyDetails(Company company) 
        {
            ID = company.ID;
            Name = company.Name;
            PhoneNumber = company.PhoneNumber;
            Email = company.Email;
            IsEmailConfirmed = company.IsEmailConfirmed;
            Address1 = company.Address1;
            Address2 = company.Address2;
            Address3 = company.Address3;
            City = company.City;
            StateProvinceID = company.StateProvinceID;
            ZipCode = company.ZipCode;
            URL = company.URL;
            BusinessHours = company.BusinessHours;
            TimeZoneID = company.TimeZoneID;
            //SubscriptionType = company.SubscriptionType;
            //SubscriptionExpirationDateUTC = company.SubscriptionExpirationDateUTC;
        }

        [Required]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        public long CountryID { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [ColumnLabel("Email Confirmed")]
        [ColumnEditable(ColumnEditOption.Checkbox)]
        public bool IsEmailConfirmed { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string Address1 { get; set; }

        [DataType(DataType.Text)]
        public string Address2 { get; set; }

        [DataType(DataType.Text)]
        public string Address3 { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public long StateProvinceID { get; set; }
        public IEnumerable<SelectListItem> StateProvinceList { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "URL / Website")]
        [DataType(DataType.Url)]
        public string URL { get; set; }

        [Display(Name = "Hours of Operation")]
        [DataType(DataType.Text)]
        public string BusinessHours { get; set; } //TODO - use custom function here to translate between string and structured data

        [Required]
        [Display(Name = "Time Zone")]
        public long TimeZoneID { get; set; }
        public IEnumerable<SelectListItem> TimeZoneList { get; set; }

        ////[ColumnEditable(ColumnEditOption.Text)]
        //public string SubscriptionType { get; set; }

        ////[ColumnEditable(ColumnEditOption.Text)]
        //public DateTime SubscriptionExpirationDateUTC { get; set; }
    }

    public class CompanyUsersAdmin
    {
        public CompanyUsersAdmin() { }

        public CompanyUsersAdmin(ApplicationUser user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Name = $"{user.LastName}, {user.FirstName}";
            this.Email = user.Email;
            this.EmailConfirmed = user.EmailConfirmed;
            this.PhoneNumber = user.PhoneNumber;
            this.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            this.TwoFactorEnabled = user.TwoFactorEnabled;
            this.LockoutEnabled = user.LockoutEnabled;
            this.AccessFailedCount = user.AccessFailedCount;
        }

        [ColumnPk]
        [ColumnDynamicModal("", "", ModalSize.Large, buttonType: ModalButtonType.PrimaryOutlineBlue)]
        public string Id { get; set; }

        [ColumnLabel("User Name")]
        public string UserName { get; set; }
        public string Name { get; set; } //"LastName, FirstName"
        public string Email { get; set; }

        [ColumnLabel("Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [ColumnLabel("Phone #")]
        public string PhoneNumber { get; set; }

        [ColumnLabel("Phone # Confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [ColumnLabel("Two Factor Authentication Enabled")]
        public bool TwoFactorEnabled { get; set; }
        //public DateTime LockOutEnd { get; set; }

        [ColumnLabel("Locked Out")]
        public bool LockoutEnabled { get; set; }
        
        [ColumnLabel("Failed Login Attempts")]
        public int AccessFailedCount { get; set; }
        //Company Role?
        //Application Role?

        public ApplicationUser GetUser()
        {
            string firstName = "";
            string lastName = "";
            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                string[] parts = this.Name.Split(", ");
                firstName = parts[1];
                lastName = parts[0];
            }

            return new ApplicationUser()
            {
                Id = this.Id,
                FirstName = firstName,
                LastName = lastName,
                UserName = this.UserName,
                Email = this.Email,
                EmailConfirmed = this.EmailConfirmed,
                PhoneNumber = this.PhoneNumber,
                PhoneNumberConfirmed = this.PhoneNumberConfirmed,
                TwoFactorEnabled = this.TwoFactorEnabled,
                LockoutEnabled = this.LockoutEnabled,
                AccessFailedCount = this.AccessFailedCount
            };
        }
    }
}
