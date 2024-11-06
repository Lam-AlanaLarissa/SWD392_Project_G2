using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        using (var client = new SmtpClient("your.smtp.server"))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("your_email@example.com", "your_password");
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your_email@example.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email);
            await client.SendMailAsync(mailMessage);
        }
    }
}
