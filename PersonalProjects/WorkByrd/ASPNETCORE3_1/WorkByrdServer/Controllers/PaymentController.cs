using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkByrdLibrary.Configuration;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Logging;
using WorkByrdLibrary.Objects;
using WorkByrdLibrary.Services;
using WorkByrdLibrary.Extensions;
using WorkByrdServer.Models;
using Taxjar;
using Stripe;
using System.IO;

namespace WorkByrdServer.Controllers
{
    public class PaymentController : BaseController
    {
        public PaymentController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IWorkByrdDbLogger dbLogger,
            IPaymentService paymentService,
            StripeConfig stripeConfig) :
            base(context, userManager, httpContextAccessor, dbLogger)
        {
            _paymentService = paymentService;
            _stripeConfig = stripeConfig;
        }

        private IPaymentService _paymentService { get; set; }
        private readonly StripeConfig _stripeConfig;

        [HttpGet]
        public ActionResult Subscription()
        {
            SubscriptionViewModel model = new SubscriptionViewModel();
            var query = from u in _context.Users
                        join e in _context.CompanyEmployees
                        on u.Id equals e.UserID
                        join c in _context.Companies
                        on e.CompanyID equals c.ID
                        where u.Id == _context.UserID
                        select c;

            model.StripeCustomerID = query.FirstOrDefault().StripeCustomerID;
            model.Config = _stripeConfig;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PreparePayment()
        {
            try
            {
                string chosenSubscription = HttpContext.Request.Form["Subscription"];
                string stripeCustomerID = HttpContext.Request.Form["StripeCustomerID"];
                string paymentIntentID = HttpContext.Request.Form["PaymentIntentID"];

                if (string.IsNullOrWhiteSpace(chosenSubscription))
                {
                    throw new ArgumentNullException("Subscription");
                }

                SubscriptionType subscription = chosenSubscription.ToEnum<SubscriptionType>();

                TaxResponseAttributes breakdown = await _paymentService.CalculateTaxes(subscription, _context.UserID);
                string paymentIntentClientSecret = "";

                if (string.IsNullOrWhiteSpace(paymentIntentID))
                {
                    //TODO - may need to send in paymentmethodid here...
                    PaymentIntent intent = await _paymentService.CreatePaymentIntent(stripeCustomerID, breakdown, subscription);
                    paymentIntentID = intent.Id;
                    paymentIntentClientSecret = intent.ClientSecret;
                }
                else
                {
                    //TODO - may need to send in paymentmethodid here...
                    PaymentIntent intent = await _paymentService.UpdatePaymentIntent(paymentIntentID, breakdown, subscription);
                    paymentIntentID = intent.Id;
                    paymentIntentClientSecret = intent.ClientSecret;
                }

                JsonResponse response = new JsonResponse();
                response.AddSuccessData("Breakdown", breakdown);
                response.AddSuccessData("PaymentIntentClientSecret", paymentIntentClientSecret);
                response.AddSuccessData("PaymentIntentID", paymentIntentID);
                return Json(response.GetRawJsonResponse());
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, EntryPoint.MVC, "[POST]PaymentController/PreparePayment", LogLevel.Error, _context.UserID);
                JsonResponse response = new JsonResponse();
                response.AddErrorData("Message", "An error occurred while trying to prepare a payment.");
                return Json(response.GetRawJsonResponse());
            }
        }

        /// <summary>
        /// TESTING: 
        ///     - (cmd) > stripe login
        ///     - (cmd) > stripe listen --events payment_intent.payment_failed,payment_intent.canceled,payment_intent.succeeded --forward-to https://localhost:44305/Payment/StripeWebhook
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> StripeWebhook()
        {
            string json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            const string endpointSecret = ""; //TODO: move to the config file... //provided by the CLI dynamically or when configured in stripe from the dashboard.

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                switch (stripeEvent.Type)
                {
                    case Events.PaymentIntentSucceeded:
                        {
                            PaymentIntent paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                            //UPDATE THE USER'S SUBSCRIPTION HERE...
                            //SEND EMAIL CONFIRMATION TO THE USER HERE...
                            //SAVE THE PAYMENT METHOD HERE...
                        }
                        break;
                    case Events.PaymentIntentCanceled:
                        {
                            PaymentIntent paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                            //SEND EMAIL NOTIFICATION HERE...
                        }
                        break;
                    case Events.PaymentIntentPaymentFailed:
                        {
                            PaymentIntent paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                            //SEND EMAIL NOTIFICATION HERE...
                        }
                        break;
                    default:
                        return BadRequest();
                }

                // Handle the event
                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    Console.WriteLine("PaymentIntent was successful!");
                }
                else if (stripeEvent.Type == Events.PaymentMethodAttached)
                {
                    var paymentMethod = stripeEvent.Data.Object as PaymentMethod;
                    Console.WriteLine("PaymentMethod was attached to a Customer!");
                }
                // ... handle other event types
                else
                {
                    // Unexpected event type
                    return BadRequest();
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
