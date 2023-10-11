using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
using System.Net.Mail;

namespace TestProject.Models
{
    public class clsEmailConfirm : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fmail = "anouri339@gmail.com";
            var fpass = "dgjyhnnyihhzvyqp";
            var themsg = new MailMessage();
            themsg.From = new MailAddress(fmail);
            themsg.Subject = subject;
            themsg.To.Add(email);
            themsg.Body= $"<html><body>{htmlMessage} </body></html>";
            themsg.IsBodyHtml = true;

            var smtpclient = new SmtpClient("smtp.gmail.com") { EnableSsl = true, Credentials = new NetworkCredential(fmail, fpass), Port = 587 };
            smtpclient.Send(themsg);
        }
    }
}
