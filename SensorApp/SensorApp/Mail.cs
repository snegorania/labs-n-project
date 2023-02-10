using System.Net;
using System.Net.Mail;

namespace SensorApp
{
    public class Mail
    {
        public static void sendEmail()
        {
            string fromMail = "makemessageforlab@gmail.com";
            string password = "ubmjllbgbmxfhevz";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test message";
            message.To.Add(new MailAddress("ek.smuraga@gmail.com"));
            message.Body = "<html><body>Test message</body></html>";
            message.IsBodyHtml= true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials= new NetworkCredential(fromMail, password),
                EnableSsl= true,
            };

            smtpClient.Send(message);
        }
    }
}
