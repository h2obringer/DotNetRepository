using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Logging;
using WorkByrdLibrary.Objects;
using WorkByrdLibrary.Services;
using WorkByrdLibrary.Utils;

namespace WorkByrdServer.Controllers
{
    public class WorkByrdAdminController : BaseController
    {
        private readonly IEmailService _emailService;

        public WorkByrdAdminController(
           ApplicationDbContext context,
           IHttpContextAccessor httpContextAccessor,
           UserManager<ApplicationUser> userManager,
           IEmailService emailService,
           IWorkByrdDbLogger dbLogger)
            : base(context, userManager, httpContextAccessor, dbLogger)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Geography()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> StateProvinces()
        {
            List<Models.StateProvinceAdmin> model = new List<Models.StateProvinceAdmin>();
            try
            {
                model =
                _context.StateProvinces.AsNoTracking()
                    .Select(s =>
                        new Models.StateProvinceAdmin(s)
                    ).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[GET]WorkByrdAdmin/StateProvinces", LogLevel.Error);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> StateProvinces(List<Models.StateProvinceAdmin> model)
        {
            try
            {
                Dictionary<long, StateProvince> pairs = new Dictionary<long, StateProvince>();
                foreach (var sp in model)
                {
                    if (sp.IsChanged == true)
                    {
                        pairs.Add(sp.ID, sp.GetStateProvince());
                    }
                }

                if (pairs.Count == 0)
                {
                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "There were no changes present. Nothing has been updated.");
                    return Json(response.GetRawJsonResponse());
                }
                else
                {
                    List<StateProvince> stateProvinces = await _context.StateProvinces
                        .Where(x => pairs.Keys.ToArray().Contains(x.ID)).ToListAsync();

                    for (int i = 0; i < stateProvinces.Count; i++)
                    {
                        StateProvince sp = stateProvinces[i];
                        if (pairs.TryGetValue(sp.ID, out sp))
                        {
                            //stateProvinces[i].Name = sp.Name; //The name is not editable...
                            stateProvinces[i].Abbreviation = sp.Abbreviation;
                            stateProvinces[i].HasTaxNexus = sp.HasTaxNexus;
                            _context.StateProvinces.Update(stateProvinces[i]);
                        }
                        else
                        {
                            throw new InvalidOperationException("An error occurred while attempting to update the StateProvince database information. A data mismatch is present.");
                        }
                    }
                    await _context.SaveChangesAsync();

                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "StateProvince information has been updated successfully.");
                    return Json(response.GetRawJsonResponse());
                }
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[POST]WorkByrdAdmin/StateProvinces", LogLevel.Error);
                JsonResponse response = new JsonResponse("Message", "An error occurred on the server while attempting to update StateProvince information.", false);
                return Json(response.GetRawJsonResponse());
            }
        }

        [HttpGet]
        public async Task<ActionResult> Countries()
        {
            List<Models.CountryAdmin> model = new List<Models.CountryAdmin>();
            try
            {
                model =
                _context.Countries.AsNoTracking()
                    //.OrderBy(c => c.Name)
                    .Select(c =>                        
                        new Models.CountryAdmin(c)
                    ).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[GET]WorkByrdAdmin/Countries", LogLevel.Error);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Countries(List<Models.CountryAdmin> model)
        {
            try { 
                Dictionary<long, Country> pairs = new Dictionary<long, Country>();
                foreach(var country in model)
                {
                    if(country.IsChanged == true)
                    {
                        pairs.Add(country.ID, country.GetCountry());
                    }
                }
                
                if(pairs.Count == 0)
                {
                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "There were no changes present. Nothing has been updated.");
                    return Json(response.GetRawJsonResponse());
                }
                else
                {
                    List<Country> countries = await _context.Countries
                        .Where(x => pairs.Keys.ToArray().Contains(x.ID)).ToListAsync();

                    for (int i = 0; i < countries.Count; i++)
                    {
                        Country country = countries[i];
                        if (pairs.TryGetValue(country.ID, out country))
                        {
                            countries[i].Abbreviation = country.Abbreviation;
                            countries[i].Name = country.Name;
                            countries[i].IsActive = country.IsActive;
                            _context.Countries.Update(countries[i]);
                        }
                        else
                        {
                            throw new InvalidOperationException("An error occurred while attempting to update the Country database information. A data mismatch is present.");
                        }
                    }
                    await _context.SaveChangesAsync();

                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "Country information has been updated successfully.");
                    return Json(response.GetRawJsonResponse());
                }
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[POST]WorkByrdAdmin/Countries", LogLevel.Error);
                JsonResponse response = new JsonResponse("Message", "An error occurred on the server while attempting to update Country information.", false);
                return Json(response.GetRawJsonResponse());
            }
        }

        [HttpGet]
        public async Task<ActionResult> TimeZones()
        {
            List<Models.TimeZoneAdmin> model = new List<Models.TimeZoneAdmin>();
            try
            {
                model =
                _context.TimeZones.AsNoTracking()
                    .Select(z =>
                        new Models.TimeZoneAdmin(z)
                    ).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[GET]WorkByrdAdmin/TimeZones", LogLevel.Error);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TimeZones(List<Models.TimeZoneAdmin> model)
        {
            try
            {
                Dictionary<long, WorkByrdLibrary.EntityFramework.Tables.TimeZone> pairs = new Dictionary<long, WorkByrdLibrary.EntityFramework.Tables.TimeZone>();
                foreach (var zone in model)
                {
                    if (zone.IsChanged == true)
                    {
                        pairs.Add(zone.ID, zone.GetTimeZone());
                    }
                }

                if (pairs.Count == 0)
                {
                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "There were no changes present. Nothing has been updated.");
                    return Json(response.GetRawJsonResponse());
                }
                else
                {
                    List<WorkByrdLibrary.EntityFramework.Tables.TimeZone> zones = await _context.TimeZones
                        .Where(x => pairs.Keys.ToArray().Contains(x.ID)).ToListAsync();

                    for (int i = 0; i < zones.Count; i++)
                    {
                        WorkByrdLibrary.EntityFramework.Tables.TimeZone zone = zones[i];
                        if (pairs.TryGetValue(zone.ID, out zone))
                        {
                            zones[i].Abbreviation = zone.Abbreviation;
                            zones[i].UtcOffset = zone.UtcOffset;
                            zones[i].Zone = zone.Zone;
                            zones[i].IsActive = zone.IsActive;
                            _context.TimeZones.Update(zones[i]);
                        }
                        else
                        {
                            throw new InvalidOperationException("An error occurred while attempting to update the TimeZone database information. A data mismatch is present.");
                        }
                    }
                    await _context.SaveChangesAsync();

                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "TimeZone information has been updated successfully.");
                    return Json(response.GetRawJsonResponse());
                }
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[POST]WorkByrdAdmin/TimeZones", LogLevel.Error);
                JsonResponse response = new JsonResponse("Message", "An error occurred on the server while attempting to update TimeZone information.", false);
                return Json(response.GetRawJsonResponse());
            }
        }

        [HttpGet]
        public async Task<ActionResult> Companies()
        {
            List<Models.CompanyAdmin> model = new List<Models.CompanyAdmin>();
            try
            {
                model =
                _context.Companies.AsNoTracking()
                    .Select(c =>
                        new Models.CompanyAdmin(c)
                    ).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[GET]WorkByrdAdmin/Companies", LogLevel.Error);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> CompanyDetails(string id)
        {
            Models.CompanyDetails model = new Models.CompanyDetails();
            try
            {
                //COMPANY INFO
                model = _context.Companies.AsNoTracking()
                    .Where(c => c.ID == id)
                    .Select(c =>
                        new Models.CompanyDetails(c)
                    )
                    .FirstOrDefault();

                //single query to prevent querying the database multiple times...
                var stateCountryQuery = from c in _context.Countries.AsNoTracking()
                                        join sp in _context.StateProvinces.AsNoTracking()
                                        on c.ID equals sp.CountryID
                                        where c.IsActive == true || sp.ID == model.StateProvinceID
                                        select new { c, sp }; //the company's country could have been deactivated after the company was created
                
                long selectedcountryid = stateCountryQuery.Where(i => i.sp.ID == model.StateProvinceID).Select(i => i.c.ID).FirstOrDefault();

                //COUNTRY LIST
                List<SelectListItem> CountryList = stateCountryQuery
                    .Select(c => new SelectListItem
                        {
                            Value = c.c.ID.ToString(),
                            Text = c.c.Name
                            //do not set Selected = c.sp.ID == model.StateProvinceID or Distinct will still provide a duplicate (an entry with Selected = false and another with Selected = true)
                        })
                    .Distinct()
                    .ToList();
                SelectListItem current = CountryList.Find(i => i.Value == selectedcountryid.ToString());
                current.Selected = true; //finally set the selected country appropriately here
                model.CountryList = CountryList;

                //STATEPROVINCE LIST
                List<SelectListItem> StateProvinceList = stateCountryQuery
                    .Where(i => i.c.ID == selectedcountryid)
                    .Select(i => new SelectListItem
                    {
                        Value = i.sp.ID.ToString(),
                        Text = i.sp.Name,
                        Selected = i.sp.ID == model.StateProvinceID
                    }).ToList();
                model.StateProvinceList = StateProvinceList;

                //TIMEZONE LIST
                List<SelectListItem> TimeZoneList = _context.TimeZones.AsNoTracking()
                    .Where(t => t.IsActive == true || t.ID == model.TimeZoneID)
                    .OrderBy(t => t.Zone)
                    .Select(t =>
                    new SelectListItem
                    {
                        Value = t.ID.ToString(),
                        Text = t.Zone,
                        Selected = t.ID == model.TimeZoneID
                    }).ToList();
                model.TimeZoneList = TimeZoneList;

                return PartialView("_Company", model);

            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[GET]WorkByrdAdmin/CompanyDetails", LogLevel.Error);
                return PartialView("_Company", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCompanyDetails(Models.CompanyDetails model)
        {
            if (ModelState.IsValid || string.IsNullOrWhiteSpace(model.ID))
            {
                try
                {
                    Company company = _context.Companies
                        .Where(c => c.ID == model.ID).FirstOrDefault();
                    if (company == null) throw new ArgumentNullException($"Unable to find the specified company with ID: {model.ID}");

                    company.Address1 = model.Address1;
                    company.Address2 = model.Address2;
                    company.Address3 = model.Address3;
                    company.BusinessHours = model.BusinessHours;
                    company.City = model.City;
                    company.Email = model.Email;
                    company.IsEmailConfirmed = model.IsEmailConfirmed;
                    company.Name = model.Name;
                    company.PhoneNumber = model.PhoneNumber;
                    company.StateProvinceID = model.StateProvinceID;
                    //company.SubscriptionExpirationDateUTC = model.subsc
                    //company.SubscriptionType = model.subscript
                    company.TimeZoneID = model.TimeZoneID;
                    company.URL = model.URL;
                    company.ZipCode = model.ZipCode;

                    await _context.SaveChangesAsync();

                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "Company information has been updated successfully.");
                    return Json(response.GetRawJsonResponse());
                }
                catch (Exception ex)
                {
                    await _logger.Log(ex, EntryPoint.MVC, "[POST]WorkByrdAdminController/CompanyDetails", LogLevel.Error);
                    JsonResponse response = new JsonResponse("Message", "An error occurred on the server while attempting to update a company entry. Please try again later or call customer service.", false);
                    return Json(response.GetRawJsonResponse());
                }
            }
            else
            {
                await _logger.Log("Invalid Model State.", EntryPoint.MVC, "[POST]WorkByrdAdminController/CompanyDetails", LogLevel.Error);

                JsonResponse response = new JsonResponse("Message", "An error occurred on the server while attempting to update a company entry. Please try again later or call customer service.", false);
                return Json(response.GetRawJsonResponse());
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteCompany(Models.CompanyDetails model)
        //{
        //    if (ModelState.IsValid || string.IsNullOrWhiteSpace(model.ID))
        //    {
        //        try
        //        {
        //            Company company = _context.Companies
        //                .Where(c => c.ID == model.ID).FirstOrDefault();
        //            if (company == null) throw new ArgumentNullException($"Unable to find the specificied company with ID: {model.ID}");

        //            company.Address1 = model.Address1;
        //            company.Address2 = model.Address2;
        //            company.Address3 = model.Address3;
        //            company.BusinessHours = model.BusinessHours;
        //            company.City = model.City;
        //            company.Email = model.Email;
        //            company.IsEmailConfirmed = model.IsEmailConfirmed;
        //            company.Name = model.Name;
        //            company.PhoneNumber = model.PhoneNumber;
        //            company.StateProvinceID = model.StateProvinceID;
        //            //company.SubscriptionExpirationDateUTC = model.subsc
        //            //company.SubscriptionType = model.subscript
        //            company.TimeZoneID = model.TimeZoneID;
        //            company.URL = model.URL;
        //            company.ZipCode = model.ZipCode;

        //            await _context.SaveChangesAsync();

        //            JsonResponse response = new JsonResponse();
        //            response.AddSuccessData("Message", "Company information has been updated successfully.");
        //            return Json(response.GetRawJsonResponse());
        //        }
        //        catch (Exception ex)
        //        {
        //            await _logger.Log(ex, EntryPoint.MVC, "WorkByrdAdminController/CompanyDetails", LogLevel.Error);
        //            JsonResponse response = new JsonResponse("Message", "An error occurred on the server while attempting to update a company entry. Please try again later or call customer service.", false);
        //            return Json(response.GetRawJsonResponse());
        //        }
        //    }
        //    else
        //    {
        //        await _logger.Log("Invalid Model State.", EntryPoint.MVC, "WorkByrdAdminController/CompanyDetails", LogLevel.Error);

        //        JsonResponse response = new JsonResponse("Message", "An error occurred on the server while attempting to update a company entry. Please try again later or call customer service.", false);
        //        return Json(response.GetRawJsonResponse());
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult> CompanyUsers(string id)
        {
            List<Models.CompanyUsersAdmin> model = new List<Models.CompanyUsersAdmin>();
            try
            {
                string companyName = _context.Companies.AsNoTracking()
                    .Where(c=>c.ID == id).Select(c => c.Name).FirstOrDefault();

                model = (from c in _context.Companies
                        join ce in _context.CompanyEmployees
                        on c.ID equals ce.CompanyID
                        join u in _context.Users
                        on ce.UserID equals u.Id
                        where c.ID == id
                        select new Models.CompanyUsersAdmin(u)).ToList();

                ViewData["CompanyName"] = companyName;
                ViewData["CompanyID"] = id;

                return View(model);
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[GET]WorkByrdAdmin/CompanyUsers", LogLevel.Error);
                return View(model);
            }
        }
    }
}
