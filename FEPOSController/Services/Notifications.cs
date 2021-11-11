using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace FEPOSController.Services
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string toEmail, string toName)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("stivenvelezbedoya@gmail.com", "Stiven Vélez Bedoya");
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = client.SendEmailAsync(msg);
            return true;
        }

        public Boolean SendSMS(string content, string to, string from)
        {
            //twilio service
            return true;
        }
    }
}
