using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
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
            var senderEmail = _configuration["EmailSettings:Email"];
            var appPassword = _configuration["EmailSettings:AppPassword"];

            Console.WriteLine($"Sender: {senderEmail}");
            Console.WriteLine($"Password exists: {!string.IsNullOrEmpty(appPassword)}");
            Console.WriteLine($"Recipient: {to}");

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(
                "Cinema Ticket Booking",
                senderEmail));

            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            email.Body = new TextPart("plain")
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            smtp.Connect(
                "smtp.gmail.com",
                587,
                SecureSocketOptions.StartTls);

            Console.WriteLine("Connected to Gmail.");

            smtp.Authenticate(senderEmail, appPassword);

            Console.WriteLine("Authenticated successfully.");

            smtp.Send(email);

            Console.WriteLine("Email sent successfully.");

            smtp.Disconnect(true);
        }


    }
}
