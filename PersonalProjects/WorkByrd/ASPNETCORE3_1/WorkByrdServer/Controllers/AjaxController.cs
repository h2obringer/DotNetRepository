using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Logging;
using WorkByrdLibrary.Utils;

namespace WorkByrdServer.Controllers
{
    public class AjaxController : BaseController
    {
        public AjaxController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IWorkByrdDbLogger dbLogger) :
            base(context, userManager, httpContextAccessor, dbLogger)
        {

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult GetSecureStateProvinces()
        {
            decimal countryId = DataUtils.GetDecimal(Request.Form["CountryID"].ToString());
            List<SelectListItem> stateProvincesList;
            stateProvincesList = _context.StateProvinces.Where(s => s.CountryID == countryId).OrderBy(s => s.Name)
                .Select(s =>
                new SelectListItem
                {
                    Value = s.ID.ToString(),
                    Text = s.Name
                }).ToList();
            stateProvincesList.Add(new SelectListItem { Value = " ", Text = " ", Selected = true });

            return Json(stateProvincesList);
        }

    }
}
