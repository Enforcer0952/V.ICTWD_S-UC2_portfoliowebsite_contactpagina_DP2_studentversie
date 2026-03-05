using System.Net;
using System.Net.Mail;

namespace Portfoliowebsite.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public SmtpEmailSender(IConfiguration config) => _config = config;

        public async Task SendAsync(string Name, string Email, string Subject, string Message)
        {
            SmtpClient smtp = new SmtpClient(_config["Smtp:Host"], int.Parse(_config["Smtp:Port"]!))
            {
                EnableSsl = bool.Parse(_config["Smtp:EnableSsl"]!),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"])
            };

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_config["Smtp:FromAddress"]!, _config["Smtp:FromName"]);
            mail.To.Add(_config["Smtp:ToAddress"]!);
            mail.Subject = $"Contact: {Subject}";
            mail.Body = $"Naam: {Name}\nEmail: {Email}\nBericht:\n{Message}";

            await smtp.SendMailAsync(mail);
        }
    }
}
