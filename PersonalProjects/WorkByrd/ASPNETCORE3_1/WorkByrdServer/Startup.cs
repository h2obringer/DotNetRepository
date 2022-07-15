using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkByrdLibrary.EntityFramework;
using WorkByrdLibrary.Services;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Logging;
using WorkByrdLibrary.Configuration;
using Microsoft.AspNetCore.Http;
using WorkByrdLibrary.EntityFramework.Triggers;
using Microsoft.AspNetCore.Http.Features;
using System;
using WorkByrdLibrary.Extensions;

namespace WorkByrdServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// This method gets called by the runtime. This method registers services to the dependency injection (DI) container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                //https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Unspecified;
                options.OnAppendCookie = cookieContext => CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);

            });

            RegisterCoreDI(services);
            RegisterModelBindingOptions(services);
            RegisterDbContextDI(services);
            RegisterIdentitySystemDI(services);

            RegisterScopedServicesDI(services);
            RegisterTransientServicesDI(services);
            RegisterSingletonServicesDI(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// This method gets called by the runtime. It establishes the MIDDLEWARE PIPELINE. 
        /// The order that each middleware component is added to the pipeline is the order in which they are executed in the pipeline. 
        /// Order is extemely important towards the security and performance of the application. Some middleware is dependent on being called
        /// before or after other middleware components.
        /// Terminal Middleware end the pipeline early and prevent downstream middleware and endpoints from executing. Terminal middleware 
        /// does not call the 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //Per OWASP, HTTP Strict Transport Security (HSTS) is an opt-in security enhancement that's specified by a weeb app through the use of a response header.
                //When a browser that supports HSTS receives this header:
                //  The browser stores configuration for the domain that prevents sending any communication over HTTP. 
                //  The browser forces all communication over HTTPS. The browser prevents the user from using untrusted or invalid certificates. the browser disables prompts 
                //  that allow a user to temporarily trust such a certificate.
                //Because HSTS is enforced by the client, it has some limitations:
                //  The client must support HSTS.
                //  HSTS requires at least one successful HTTPS request to establish the HSTS policy.
                //  The application must check every HTTP request and redirect or reject the HTTP request.
                app.UseHsts();
            }

            new TriggerDefinitions();

            //Requires HTTPS for all requests
            //Redirects all HTTP requests to HTTPS
            app.UseHttpsRedirection();

            //allows serving static files
            //can pass in a new StaticFileOptions class to provide additional control
            app.UseStaticFiles();


            //Use cookies with the site.
            //can pass in a new CookiePolicyOptions class to provide additional control
            app.UseCookiePolicy(); //https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1

            //adds route matching to the middleware pipeline. This middleware looks at the set of endpoints defined in the app, and select the best match based on the request.
            app.UseRouting();

            //app.UseRequestLocalization();
            //app.UseCors();

            //
            app.UseAuthentication();
            
            //
            app.UseAuthorization();

            //app.UseSession();

            //****************************************START CUSTOM MIDDLEWARE****************************************
            app.UseAccountEnforcerMiddleware();
            //****************************************END CUSTOM MIDDLEWARE******************************************


            //adds endpoint execution to the middleware pipeline. It runs the delegate associated with the selected endpoint.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        //https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
        private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                if (DisallowsSameSiteNone(userAgent))
                {
                    options.SameSite = SameSiteMode.Unspecified;
                }
            }
        }


        private void RegisterCoreDI(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        private void RegisterModelBindingOptions(IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                //NOTE: the controller model parameter will be passed in as null if the Request.Form.Count exceeds this value...
                options.ValueCountLimit = int.MaxValue; // //2,147,483,647 items max
                //options.ValueLengthLimit = 1024 * 1024 * 100; // 100MB max len form data
            });
            
        }

        private void RegisterDbContextDI(IServiceCollection services)
        {
            //Signature: (ApplicationDbContext context)
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("WorkByrdDB")));
        }

        private void RegisterIdentitySystemDI(IServiceCollection services)
        {
            ///Registers the following signatures: 
            //  (UserManager<ApplicationUser> userManager)
            //  (SignInManager<ApplicationUser> signInManager)
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options => {
                    options.SignIn.RequireConfirmedAccount = true;

                    //set lockout options
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    //set minimum password requirements. 
                    //See Startup.cs:RegisterIdentitySystemDI() if changes are made here...
                    //See AccountController:RegisterUser if changes are made here...
                    //See AccountViewModels.cs:RegisterUserViewModel and ResetPasswordViewModel if changes are made here...
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;

                    //set user restrictions
                    options.User.RequireUniqueEmail = true;

                    //options.ClaimsIdentity.SecurityStampClaimType = "AspNet.Identity.SecurityStamp"; //default
                    //options.ClaimsIdentity.UserNameClaimType = "System.Security.Claims.ClaimTypes.Name"; //default
                    //options.ClaimsIdentity.UserIdClaimType = "System.Security.Claims.ClaimTypes.NameIdentifier"; //default
                    //options.ClaimsIdentity.RoleClaimType = "System.Security.Claims.ClaimTypes.Role"; //default
                    
                    //options.Tokens.AuthenticatorIssuer;
                    //options.Tokens.AuthenticatorTokenProvider;
                    //options.Tokens.ChangeEmailTokenProvider;
                    //options.Tokens.ChangePhoneNumberTokenProvider;
                    //options.Tokens.EmailConfirmationTokenProvider;
                    //options.Tokens.PasswordResetTokenProvider;
                    //options.Tokens.ProviderMap;
                }
            )
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Account/Login";
                options.LogoutPath = $"/Account/Logout";
                options.AccessDeniedPath = $"/Account/AccessDenied";
            });
        }

        private void RegisterScopedServicesDI(IServiceCollection services)
        {
            ////Signature: (IWorkByrdDbLogger dbLogger)
            //services.AddScoped<IWorkByrdDbLogger, WorkByrdDbLogger>();
            ////Signature: (IEmailService emailService)
            //services.AddScoped<IEmailService, EmailService>();
        }

        private void RegisterTransientServicesDI(IServiceCollection services)
        {
            //Signature: (IWorkByrdDbLogger dbLogger)
            services.AddTransient<IWorkByrdDbLogger, WorkByrdDbLogger>();
            //Signature: (IUserAccessLogger userLogger)
            services.AddTransient<IUserAccessLogger, UserAccessLogger>();
            //Signature: (IEmailService emailService)
            services.AddTransient<IEmailService, EmailService>();
            //Signature: (IPaymentService paymentService)
            services.AddTransient<IPaymentService, StripePaymentService>();
        }

        private void RegisterSingletonServicesDI(IServiceCollection services)
        {
            //Signature: (IHttpContextAccessor httpContextAccessor)
            services.AddHttpContextAccessor();
            
            //Signature: (EmailConfig emailConfig)
            EmailConfig emailConfig = new EmailConfig();
            Configuration.GetSection("EmailSettings").Bind(emailConfig);
            services.AddSingleton(emailConfig);

            //Signature: (StripeConfig stripeConfig)
            StripeConfig stripeConfig = new StripeConfig();
            Configuration.GetSection("Stripe").Bind(stripeConfig);
            stripeConfig.Validate(); //ensure we have correct data in the configuration file in order to start the program...
            services.AddSingleton(stripeConfig);
        }

        //https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
        private bool DisallowsSameSiteNone(string userAgent)
        {
            // Cover all iOS based browsers here. This includes:
            // - Safari on iOS 12 for iPhone, iPod Touch, iPad
            // - WkWebview on iOS 12 for iPhone, iPod Touch, iPad
            // - Chrome on iOS 12 for iPhone, iPod Touch, iPad
            // All of which are broken by SameSite=None, because they use the iOS networking
            // stack.
            if (userAgent.Contains("CPU iPhone OS 12") ||
                userAgent.Contains("iPad; CPU OS 12"))
            {
                return true;
            }

            // Cover Mac OS X based browsers that use the Mac OS networking stack. 
            // This includes:
            // - Safari on Mac OS X.
            // This does not include:
            // - Chrome on Mac OS X
            // Because they do not use the Mac OS networking stack.
            if (userAgent.Contains("Macintosh; Intel Mac OS X 10_14") &&
                userAgent.Contains("Version/") && userAgent.Contains("Safari"))
            {
                return true;
            }

            // Cover Chrome 50-69, because some versions are broken by SameSite=None, 
            // and none in this range require it.
            // Note: this covers some pre-Chromium Edge versions, 
            // but pre-Chromium Edge does not require SameSite=None.
            if (userAgent.Contains("Chrome/5") || userAgent.Contains("Chrome/6"))
            {
                return true;
            }

            return false;
        }
    }
}
