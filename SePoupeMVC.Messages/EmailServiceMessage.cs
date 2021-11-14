using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SePoupeMVC.Messages
{
    public class EmailServiceMessage
    {
        private string _account = "poupaaiproject@gmail.com";
        private string _password = "Admin@root321";
        private string _smtp = "smtp.gmail.com";
        private int _port = 587;

        public void SendEmail(string to, string subject, string body)
        {
            //Build email
            var message = new MailMessage(_account, to);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            //Sending
            var smtp = new SmtpClient(_smtp, _port);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_account, _password);
            smtp.Send(message);
        }
    }
}
