using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.Utilities
{
    public class EmailUtility
    {
        public static void SendEmail(string toEmail, string subject, string body)
        {
            string senderEmail = "quizgame402@gmail.com";
            string senderPassword = "oyuc ogut cjhe dcua"; // Add your password here
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            try
            {
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, body);
                    mailMessage.IsBodyHtml = true;

                    client.Send(mailMessage);
                    Console.WriteLine("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
