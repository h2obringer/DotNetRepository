using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Objects;
using WorkByrdServer.Models;
using WorkByrdLibrary.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkByrdLibrary.Utils;
using Microsoft.AspNetCore.Authentication;
using WorkByrdLibrary.Logging;
using Microsoft.EntityFrameworkCore.Storage;
using WorkByrdLibrary.Extensions;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using WorkByrdLibrary.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Stripe;

namespace WorkByrdServer.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;
        private readonly IUserAccessLogger _userLogger;

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public AccountController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPaymentService paymentService,
            IHttpContextAccessor httpContextAccessor,
            IUserAccessLogger userLogger,
            IEmailService emailService,
            IWorkByrdDbLogger dbLogger) :
            base(context, userManager, httpContextAccessor, dbLogger)
        {
            _signInManager = signInManager;
            _emailService = emailService;
            _userLogger = userLogger;
            _paymentService = paymentService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && !user.EmailConfirmed)
            {
                //ModelState.AddModelError("", "You must verify your email first.");
                //return View(model);
                return RedirectToAction("CheckUserEmail", "Account", new { userid = user.Id });
            }
            //// Password failures triggering account lockouts has been enabled (shouldLockout: true)
            //// The sign-in cookie should persist after the browser is closed (when model.RememberMe = true)

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                await _userLogger.Log(model.Email, UserAccessAction.Login, EntryPoint.MVC);
                return RedirectToAction("Index", "Home");
            }
            if (result.RequiresTwoFactor)
            {
                await _userLogger.Log(model.Email, UserAccessAction.Login2fa1, EntryPoint.MVC);
                return RedirectToAction("LoginWith2fa", "Account", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            }
            if (result.IsLockedOut)
            {
                await _userLogger.Log(model.Email, UserAccessAction.LockedOut, EntryPoint.MVC);
                return RedirectToAction("Lockout", "Account");
            }
            else
            {
                await _userLogger.Log(model.Email, UserAccessAction.InvalidLoginAttempt, EntryPoint.MVC);
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

        //
        // POST: /Account/Logout
        [HttpPost]
        public async Task<ActionResult> Logout(string returnUrl)
        {
            string userName = _signInManager.Context.User.Identity.Name;
            await _signInManager.SignOutAsync();
            
            await _userLogger.Log(userName, UserAccessAction.Logout, EntryPoint.MVC);
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }

        // GET: /Account/RegisterUser
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterUser()
        {
            RegisterUserViewModel model = new RegisterUserViewModel();
            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterUser(RegisterUserViewModel model)
        {
            //returnUrl = returnUrl ?? Url.Content("~/"); //returnUrl was a parameter to this function...
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = new ApplicationUser(model.Email);
                    _context.UserID = user.Id; //User is not logged in yet so we have to pass this around through the model for our triggers...
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        user = await _userManager.FindByNameAsync(model.Email);
                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        await _emailService.SendEmailConfirmationAsync(_userManager, user, Url.BaseURL(), EntryPoint.MVC, false);

                        return RedirectToAction("CheckUserEmail", "Account", new { userid = user.Id });
                    }
                    else
                    {
                        StringBuilder msg = new StringBuilder();
                        msg.Append("Failed to create a new user. ");
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                            msg.Append($"{error.Code} - {error.Description}. ");
                        }
                        await _logger.Log(msg.ToString(), EntryPoint.MVC, "[POST]AccountController/RegisterUser", LogLevel.Warning, "");

                        return View();
                    }
                }
                catch (Exception ex)
                {
                    await _logger.Log(ex, EntryPoint.MVC, "[POST]AccountController/RegisterUser", LogLevel.Error);
                    return View();
                }
            }
            else
            {
                StringBuilder msg = new StringBuilder();
                msg.Append("Failed to create a new user. Invalid Model State. ");
                List<KeyValuePair<string, ModelStateEntry>> errors = ModelState.Where(modelError => modelError.Value.Errors.Count > 0).ToList();
                for(int i = 0; i < errors.Count; i++)
                {
                    msg.AppendLine($"{errors.ElementAt(i).Key} - {errors.ElementAt(i)}. ");
                }
                
                await _logger.Log(msg.ToString(), EntryPoint.MVC, "[POST]AccountController/RegisterUser", LogLevel.Error);

                return View();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> CheckUserEmail(string userid)
        {
            RegisterUserEmailViewModel model = new RegisterUserEmailViewModel();
            model.UserID = userid;
            ApplicationUser user = await _userManager.FindByIdAsync(userid);
            model.Email = user.Email;
            return View(model);
        }
        
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResendUserEmailVerification(RegisterUserEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await _userManager.FindByIdAsync(model.UserID);
                    await _emailService.SendEmailConfirmationAsync(_userManager, user, Url.BaseURL(), EntryPoint.MVC, false);

                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "Verification email has been resent.");
                    response.AddSuccessData("UserID", model.UserID);
                    return Json(response.GetRawJsonResponse());
                }
                catch (Exception ex)
                {
                    await _logger.Log(ex, EntryPoint.MVC, "[POST]AccountController/ResendUserEmailVerification", LogLevel.Error, model.UserID);
                    JsonResponse response = new JsonResponse();
                    response.AddErrorData("Message", "An error occurred while trying to resend email verification. Please try again later or call customer service.");
                    return Json(response.GetRawJsonResponse());
                }
            }
            else
            {
                JsonResponse response = new JsonResponse();
                response.AddErrorData("Message", "An error occurred while trying to resend email verification. Please try again later or call customer service.");
                return Json(response.GetRawJsonResponse());
            }
        }

        // GET: /Account/RegisterUser
        [HttpGet]
        public async Task<ActionResult> RegisterCompany()
        {      
            RegisterCompanyViewModel model = new RegisterCompanyViewModel();
            try
            {
                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                model.UserID = user.Id;
                model.UserEmail = user.Email;
                model.UserPhone = user.PhoneNumber;
                model.SetDropDownData(_context);                

                return View(model);
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[GET]Account/Register", LogLevel.Error);
                return View(model);
            }
        }

        //TODO: not all the same data is sent back to the user if an error occurs in this function...
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterCompany(RegisterCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company();
                company.Name = model.CompanyName;
                company.Email = model.CompanyEmail;
                company.PhoneNumber = model.CompanyPhoneNumber;

                company.Address1 = model.CompanyAddress1;
                company.Address2 = model.CompanyAddress2;
                company.Address3 = model.CompanyAddress3;
                company.City = model.CompanyCity;
                company.StateProvinceID = model.CompanyStateProvinceID;
                company.ZipCode = model.CompanyZipCode;

                company.BusinessHours = model.CompanyBusinessHours;
                company.URL = model.CompanyURL;
                company.TimeZoneID = model.CompanyTimeZoneID;

                CompanyEmployee employee = new CompanyEmployee();
                employee.UserID = model.UserID;

                try
                {
                    //find the user who created the company but swap the email for the company so we can use the UserManager built in code for Email Confirmation Verification
                    ApplicationUser user = await _userManager.FindByIdAsync(model.UserID);
                    if (user.Email == company.Email && user.EmailConfirmed == true) //the user's email should always be confirmed here but to be cautious...
                    {
                        company.IsEmailConfirmed = true;
                    }
                    else
                    {
                        user.Email = company.Email;
                    }
                    using (IDbContextTransaction transaction = _context.Database.BeginTransaction(isolationLevel: System.Data.IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            Customer customer = _paymentService.CreateCustomer(company);
                            company.StripeCustomerID = customer.Id;
                            company.StripeCreateCustomerDetails = customer.ToJson();

                            //finally add and save the company...
                            _context.Companies.Add(company);
                            await _context.SaveChangesAsync();

                            employee.CompanyID = company.ID;
                            _context.CompanyEmployees.Add(employee);
                            await _context.SaveChangesAsync();

                            //the individual that creates a company is the administrator for that company...
                            await _userManager.AddToRoleAsync(user, RoleType.CompanyAdmin.GetDescription());
                            
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch
                            {
                                //squish
                            }
                            throw;
                        }
                    }

                    if (!company.IsEmailConfirmed)
                    {
                        //remember that we are using the company email here...
                        await _emailService.SendEmailConfirmationAsync(_userManager, user, Url.BaseURL(), EntryPoint.MVC, true);
                        return RedirectToAction("CheckCompanyEmail", "Account");
                    }

                    return RedirectToAction("Subscription", "Payment");
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    await _logger.Log(ex, EntryPoint.MVC, "[POST]AccountController/RegisterCompany", LogLevel.Error, model.UserID);
                    if (ex.Contains("Violation of UNIQUE KEY"))
                    {
                        ModelState.AddModelError("CompanyName", $"The company named {company.Name} has already been registered. Contact the company's administrator to grant your account access to this company.");
                    }
                    else
                    {
                        ModelState.AddModelError("CompanyName", "An error occurred while attempting to create the company. Please try again later or call customer service.");
                    }

                    model.SetDropDownData(_context);

                    return View(model);
                }
            }
            else
            {
                await _logger.Log("Invalid Model State.", EntryPoint.MVC, "[POST]AccountController/RegisterCompany", LogLevel.Error);

                model.SetDropDownData(_context);

                return View(model);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult CheckCompanyEmail()
        {
            RegisterCompanyEmailViewModel model = new RegisterCompanyEmailViewModel();
            Company company = (from c in _context.Companies
                        join e in _context.CompanyEmployees
                        on c.ID equals e.CompanyID
                        where e.UserID == _context.UserID
                        select c).FirstOrDefault();
            model.CompanyID = company.ID;
            model.UserID = _context.UserID;
            model.Email = company.Email;

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResendCompanyEmailVerification(RegisterCompanyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Company company = _context.Companies.Where(c => c.ID == model.CompanyID).FirstOrDefault();

                    if (company == null)
                    {
                        throw new Exception(String.Format("No company exists with ID {0}", model.CompanyID));
                    }

                    //find the user who initiated the request but swap the email for the company so we can use the UserManager built in code for Email Confirmation Verification
                    ApplicationUser user = await _userManager.FindByIdAsync(model.UserID);
                    user.Email = company.Email;

                    await _emailService.SendEmailConfirmationAsync(_userManager, user, Url.BaseURL(), EntryPoint.MVC, true);

                    JsonResponse response = new JsonResponse();
                    response.AddSuccessData("Message", "Verification email has been resent.");
                    response.AddSuccessData("CompanyID", company.ID);
                    return Json(response.GetRawJsonResponse());
                }
                catch (Exception ex)
                {
                    await _logger.Log(ex, EntryPoint.MVC, "[POST]AccountController/ResendCompanyEmailVerification", LogLevel.Error, model.UserID);
                    JsonResponse response = new JsonResponse();
                    response.AddErrorData("Message", "An error occurred while trying to resend company email verification. Please try again later or call customer service.");
                    return Json(response.GetRawJsonResponse());
                }
            }
            else
            {
                await _logger.Log("Invalid Model State.", EntryPoint.MVC, "[POST]AccountController/ResendCompanyEmailVerification", LogLevel.Error, model.UserID);
                JsonResponse response = new JsonResponse();
                response.AddErrorData("Message", "An error occurred while trying to resend company email verification. Please try again later or call customer service.");
                return Json(response.GetRawJsonResponse());
            }
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> IsUserEmailVerified(RegisterUserEmailViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            ApplicationUser user = await _userManager.FindByIdAsync(model.UserID);
        //            bool isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        //            if (isEmailConfirmed)
        //            {
        //                JsonResponse response = new JsonResponse("Message", "User email is confirmed.", true);
        //                response.AddSuccessData("isConfirmed", true);
        //                return Json(response.GetRawJsonResponse());
        //            }
        //            else
        //            {
        //                JsonResponse response = new JsonResponse("Message", "User email has not yet been confirmed.", true);
        //                response.AddSuccessData("isConfirmed", false);
        //                return Json(response.GetRawJsonResponse());
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            await _logger.Log(ex, EntryPoint.MVC, "AccountController/IsUserEmailVerified", LogLevel.Error, model.UserID);
        //            JsonResponse response = new JsonResponse();
        //            response.AddErrorData("Message", "An error occurred while trying to resend email verification. Please try again later or call customer service.");
        //            return Json(response.GetRawJsonResponse());
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> IsCompanyEmailVerified(RegisterCompanyEmailViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Company company = _context.Companies.Where(c => c.ID == model.CompanyID.ToString()).FirstOrDefault();

        //            if (company.IsEmailConfirmed)
        //            {
        //                JsonResponse response = new JsonResponse("Message", "Company email is confirmed.", true);
        //                response.AddSuccessData("isConfirmed", true);
        //                return Json(response.GetRawJsonResponse());
        //            }
        //            else
        //            {
        //                JsonResponse response = new JsonResponse("Message", "Company email has not yet been confirmed.", true);
        //                response.AddSuccessData("isConfirmed", false);
        //                return Json(response.GetRawJsonResponse());
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            await _logger.Log(ex, EntryPoint.MVC, "[POST]AccountController/IsCompanyEmailVerified", LogLevel.Error);
        //            JsonResponse response = new JsonResponse();
        //            response.AddErrorData("Message", "An error occurred while trying to resend email verification. Please try again later or call customer service.");
        //            return Json(response.GetRawJsonResponse());
        //        }
        //    }
        //    else
        //    {
        //        Response.Clear();
        //        Response.StatusCode = 503;
        //        return null;
        //    }
        //}

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code, string isCompany = "0")
        {
            if (userId == null || code == null)
            {
                await _logger.Log($"Invalid request. userId: '{userId}', code: '{code}', isCompany: '{isCompany}'.", EntryPoint.MVC, "Account/ConfirmEmail", LogLevel.Info, userId);
                return View("Error");
            }
            _context.UserID = userId; //User is not logged in yet so we have to use this for our triggers...
            bool isCompanyEmail = DataUtils.GetBool(isCompany);

            try
            {
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                
                //hack solution where we send the UserID inside the company email and utilize existing UserManager capabilities with the 
                //company disguised as a user. Because users must always verify their email before they can proceed in the registration
                //process or log in, recalling this function on the user is not harmful but still confirms that the code (and therefore email)
                //was confirmed correctly. If the code doesn't match or is incorrect for the userId in which it was sent for, the User's email 
                //does not change from being confirmed to not confirmed.
                ApplicationUser user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    await _logger.Log($"Unable to load user with ID '{userId}'.", EntryPoint.MVC, "Account/ConfirmEmail", LogLevel.Info, userId);
                    return View("Error");
                }

                IdentityResult result = await _userManager.ConfirmEmailAsync(user, code);

                if (isCompanyEmail && result.Succeeded)
                {
                    Company company = (from c in _context.Companies
                                      join e in _context.CompanyEmployees
                                      on c.ID equals e.CompanyID
                                      select c).FirstOrDefault();
                    company.IsEmailConfirmed = true;
                    await _context.SaveChangesAsync();
                }

                return View(result.Succeeded ? "ConfirmEmail" : "Error");
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "Account/ConfirmEmail", LogLevel.Error, userId);
                return View("Error");
            }
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action("ResetPassword", "Account", new { code }, Request.Scheme);
                
                await _emailService.SendEmailAsync(
                    model.Email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.",
                    EntryPoint.MVC);

                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            _context.UserID = user.Id; //User is not logged in yet so we have to pass this around through the model for our triggers...
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded) //TODO - reset password does not work! https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-3.1&tabs=visual-studio
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/AccessDenied
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AccessDenied()
        {
            return View();
        }

        //
        // GET: /Account/AccessDenied
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Lockout()
        {
            return View();
        }
    }
}