using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON
{
    public static class EMailService
    {
        public static void Send(string receiver, string subject, string body,string sender = "yzlm3170@gmail.com", string passWord = "oktczfjzfohickzn" )
        {
            MailAddress senderMail = new MailAddress(sender);
            MailAddress receiverMail = new MailAddress(receiver);


            SmtpClient smtp = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderMail.Address, passWord)

            };

            using (MailMessage message = new MailMessage(senderMail, receiverMail)
            {
                Subject = subject,
                Body = body,
            })
            {
                smtp.Send(message);
            }
        }

    }
}
