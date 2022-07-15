using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MimeKit;
using WorkByrdLibrary.Configuration;
using WorkByrdLibrary.EntityFramework.Tables;
using WorkByrdLibrary.Logging;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string email, string subject, string message, EntryPoint entry);
        Task<bool> SendEmailConfirmationAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string baseURL, EntryPoint entry, bool isCompany);
    }

    public class EmailService : IEmailService
    {
        private readonly IWorkByrdDbLogger _logger;
        private readonly EmailConfig _emailConfig;

        public EmailService(IWorkByrdDbLogger dbLogger, EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
            _logger = dbLogger;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message, EntryPoint entry)
        {
            try
            {
                //gmail = "smtp.gmail.com"
                string smtpHost = _emailConfig.ServiceHost;
                //gmail = 587
                int smtpPort = _emailConfig.ServicePort;
                //your email address...
                string workbyrdEmail = _emailConfig.EmailAddress;
                //gmail: account > security > 2-step verification (under signing in to google) -> Enable. Then go to "App passwords". This password is this value...
                //Finally, click "Allow less secure applications"
                string workbyrdEmailAccessKey = _emailConfig.EmailAccessKey;

                var msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("WorkByrd Account Services", workbyrdEmail));
                msg.To.Add(new MailboxAddress(email));
                msg.Subject = subject;
                msg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    //accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(smtpHost, smtpPort, false);
                    client.Authenticate(workbyrdEmail, workbyrdEmailAccessKey);

                    client.Send(msg);
                    client.Disconnect(true);
                }

                return true;
            }catch (Exception ex)
            {
                await _logger.Log(ex, entry, "EmailSender:SendEmailConfirmation()");
                return false;
            }
        }

        public async Task<bool> SendEmailConfirmationAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string baseURL, EntryPoint entry, bool isCompany)
        {
            try
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await manager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                string callbackUrl = "";
                string subject = "";
                string body = "";

                if (isCompany)
                {
                    subject = "Confirm your Company Email";
                    callbackUrl = string.Format("{0}Account/ConfirmEmail?userId={1}&code={2}&isCompany={3}", baseURL, HttpUtility.UrlEncode(user.Id), HttpUtility.UrlEncode(code), 1);
                    body = "Please confirm your company email by clicking <a href=\"" + callbackUrl + "\">here</a>";
                }
                else
                {
                    subject = "Confirm your User Account";
                    callbackUrl = string.Format("{0}Account/ConfirmEmail?userId={1}&code={2}&isCompany={3}", baseURL, HttpUtility.UrlEncode(user.Id), HttpUtility.UrlEncode(code), 0);
                    body = "Please confirm your user account by clicking <a href=\"" + callbackUrl + "\">here</a>";
                }

                await SendEmailAsync(user.Email, subject, body, entry);
                return true;
            }
            catch (Exception ex)
            {
                await _logger.Log(ex, entry, "EmailSender:SendEmailConfirmation()");
                return false;
            }
        }
    }
}
