using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.SendEmail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OngProject.Core.Services.SendEmail
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IOrganizationService _organizationService;
        public SendEmailService(IConfiguration configuration, IOrganizationService organizationService)
        {
            _configuration = configuration;
            _organizationService = organizationService;
        }

        public async Task<bool> send(string email)
        {
           
                var apiKey = _configuration["SENDGRID_API_KEY:Key"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_configuration["SENDGRID_API_KEY:FromEmail"], "Example User");
                var subject = "Correo de api somos mas";
                var to = new EmailAddress(email, "Example User");
                var plainTextContent = "Este es el cuerpo de un correo enviado a traves de la api somos mas";
                var htmlContent = "<strong>Este es el cuerpo de un correo enviado a traves de la api somos mas</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                return response.IsSuccessStatusCode;

          
        }

        public async Task<bool> SendContatcsEmail(string email)
        {
            var apiKey = _configuration["SENDGRID_API_KEY:Key"];
            string html = File.ReadAllText("./Templates/email_template.html");

            html = html.Replace("{mail_title}", _configuration["SENDGRID_API_KEY:ContactMessage"]);
            html = html.Replace("{mail_body}", _configuration["SENDGRID_API_KEY:ContactBodyMessage"]);
            

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration["SENDGRID_API_KEY:FromEmail"]);
            var to = new EmailAddress(email);
            string subject = _configuration["SENDGRID_API_KEY:WeolcomeSubject"];
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", html);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SendRegisterEmail(string toEmail)
        {
            var organization = await _organizationService.GetFirst();

            var apiKey = _configuration["SENDGRID_API_KEY:Key"];
            string html = File.ReadAllText("./Templates/email_template.html");

            html = html.Replace("{mail_title}", _configuration["SENDGRID_API_KEY:WelcomeMessage"]);
            html = html.Replace("{mail_body}", _configuration["SENDGRID_API_KEY:ContactBodyMessage"]);
            html = html.Replace("{mail_contact}", organization.Adress + "<br>" + organization.Phone);

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration["SENDGRID_API_KEY:FromEmail"]);
            var to = new EmailAddress(toEmail);
            string subject = _configuration["SENDGRID_API_KEY:WeolcomeSubject"];
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", html);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

            return response.IsSuccessStatusCode;

        }
    }
}
