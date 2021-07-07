using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.SMTP
{
    public class MailHelper
    {
        private static string smtpServer = "mail.deuxsoft.com";
        private static int smtpPort = 587;
        private static string from = "destek@deuxsoft.com";
        private static string fromPassword = ".8BNU.uxkN016s.=";
        private static bool isBodyHtml = true;
        private static NetworkCredential networkCredential = new NetworkCredential(from, fromPassword);
        public static void SendMail(List<string> tos, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtpServer, smtpPort);

            mail.From = new MailAddress(from);
            foreach (string to in tos)
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            if (networkCredential != null)
                SmtpServer.Credentials = networkCredential;

            SmtpServer.Send(mail);
        }
        public static void SendMail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtpServer, smtpPort);

            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;
            if (networkCredential != null)
                SmtpServer.Credentials = networkCredential;

            SmtpServer.Send(mail);

        }
    }
}
