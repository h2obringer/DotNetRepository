using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.EntityFramework.Tables;

namespace WorkByrdLibrary.Middleware
{
    /// <summary>
    /// This middleware enforces user accounts and company accounts in several ways.
    /// User accounts:
    ///     - must have their email addresses confirmed so that we can contact them. If their email is not verified the
    ///         request path will be rewritten to direct the user to a screen that will allow them to resend the confirmation code link for the user.
    /// Company accounts:
    ///     - must have their company email address confirmed so that we can contact them. If their email is not verified the
    ///         request path will be rewritten to direct the user to a screen that will allow them to resend the confirmation code link for the company.
    ///     - must have an active subscription. If no subscription is on record or it is expired the request path will be rewritten to direct the user to a
    ///         screen that will allow the user to pay for or renew a subscription.
    /// </summary>
    public class AccountEnforcerMiddleware
    {
        private readonly RequestDelegate _next;

        public AccountEnforcerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //TODO - look into possibly getting this information from Session so we don't have to ping the database again for this information.
        //TODO - is it possible to check if the endpoint request has an AllowAnonymous attribute? if it is and it is present, short circuit all of the logic below
        //          for performance reasons...
        public async Task InvokeAsync(HttpContext context, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            //If the endpoint allows anonymous access then continue with the middleware pipeline. This middleware will not do anything in this case...
            Endpoint endpoint = context.GetEndpoint();
            if(endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object)
            {
                await _next(context); //continue the middleware pipeline with the given request.
                return; //nothing more is needed by the AccountEnforcerMiddleware.
            }

            //the user is allowed to logout while signed in and not assigned to a company...
            if (context.Request.Path.Value.Contains("/Account/Logout"))
            {
                await _next(context); //continue the middleware pipeline with the given request.
                return; //nothing more is needed by the AccountEnforcerMiddleware.
            }

            if(context.User != null)
            {
                ApplicationUser user = await userManager.GetUserAsync(context.User);

                if(user == null) //the user is not signed in?
                {
                    await _next(context);
                    return;
                }
                if (!user.EmailConfirmed)
                {
                    if (context.Request.Path.Value.Contains("/Account/CheckUserEmail"))
                    {
                        //the user is navigating to the correct endpoint or was redirected here.
                        await _next(context); //continue the middleware pipeline with the given request.
                        return; //nothing more is needed by the AccountEnforcerMiddleware.
                    }
                    context.Response.Redirect("/Account/CheckUserEmail");
                    return; //terminal. We are redirecting the user so do not continue to execute the middleware pipeline.
                }
                else
                {
                    var dataset = (from c in db.Companies
                                       join e in db.CompanyEmployees on c.ID equals e.CompanyID
                                       where e.UserID == user.Id
                                       select new {c, e}
                                  ).FirstOrDefault();
                    if (dataset == null) //the user is not tied to a company yet...
                    {
                        if (context.Request.Path.Value.Contains("/Account/RegisterCompany"))
                        {
                            //the user is navigating to the correct endpoint or was redirected here.
                            await _next(context); //continue the middleware pipeline with the given request.
                            return; //nothing more is needed by the AccountEnforcerMiddleware.
                        }
                        //the user is not tied to a company yet so let's redirect them to the Register Company endpoint...
                        context.Response.Redirect("/Account/RegisterCompany");
                        return; //terminal. We are redirecting the user so do not continue to execute the middleware pipeline.
                    }
                    else if (!dataset.c.IsEmailConfirmed) //the company email address is not verified yet
                    {
                        if (context.Request.Path.Value.Contains("/Account/CheckCompanyEmail"))
                        {
                            await _next(context); //continue the middleware pipeline with the given request.
                            return; //nothing more is needed by the AccountEnforcerMiddleware.
                        }
                        //the company email address is not verified yet and the current request is not already navigating to the Check Company Email endpoint so let's redirect them there...
                        context.Response.Redirect("/Account/CheckCompanyEmail");
                        return; //terminal. We are redirecting the user so do not continue to execute the middleware pipeline.
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(dataset.c.SubscriptionType)) //or subscription is expired...
                        {
                            if (context.Request.Path.Value.Contains("/Payment/Subscription"))
                            {
                                await _next(context); //continue the middleware pipeline with the given request.
                                return; //nothing more is needed by the AccountEnforcerMiddleware.
                            }
                            //the company email address is not verified yet and the current request is not already navigating to the Check Company Email endpoint so let's redirect them there...
                            context.Response.Redirect("/Payment/Subscription");
                            return; //terminal. We are redirecting the user so do not continue to execute the middleware pipeline.
                        }
                    }
                }                
            }

            await _next(context);
        }
    }
}
