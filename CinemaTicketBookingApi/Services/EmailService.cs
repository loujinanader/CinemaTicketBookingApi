using MimeKit;
using MailKit.Net.Smtp;
namespace CinemaTicketBookingApi.Services 
{ 
    public class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse("loujinanader11@gmail.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            email.Body = new TextPart("plain")
            {
                Text = body
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("loujinanader11@gmail.com", "zczs xufb bqfe aysi\r\n");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
