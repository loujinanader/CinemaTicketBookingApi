using MimeKit;
using MailKit.Net.Smtp;
namespace CinemaTicketBookingApi.Services 
{ 
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string to, string subject, string body)
        {

            var emailAddress = _configuration["EmailSettings:Email"];
            var appPassword = _configuration["EmailSettings:AppPassword"];
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(emailAddress));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            email.Body = new TextPart("plain")
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            smtp.Authenticate(emailAddress, appPassword);

            smtp.Send(email);

            smtp.Disconnect(true);
        }

    }
}
