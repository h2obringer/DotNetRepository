using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Logging;
using WorkByrdLibrary.Services;
using WorkByrdServer.Models;

namespace WorkByrdServer.Controllers
{
    public class ManageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IWorkByrdDbLogger _logger;
        private readonly IUserAccessLogger _userLogger;

        public ManageController(
           ApplicationDbContext context,
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IUserAccessLogger userLogger,
           IEmailService emailService,
           IWorkByrdDbLogger dbLogger)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _logger = dbLogger;
            _userLogger = userLogger;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            ManageIndexViewModel model = new ManageIndexViewModel();
            model.Email = user.Email;
            model.PhoneNumber = user.PhoneNumber;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ManageIndexViewModel model)
        {
            
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user, model);
                return View();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            
            await _signInManager.RefreshSignInAsync(user);
            TempData.Add("StatusMessage", "Your profile has been updated");
            return View();
        }

        private async Task LoadAsync(ApplicationUser user, ManageIndexViewModel model)
        {
            model.Email = await _userManager.GetUserNameAsync(user);
            model.PhoneNumber = await _userManager.GetPhoneNumberAsync(user);
        }
    }
}
