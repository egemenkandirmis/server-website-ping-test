using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace server_website_ping_test.Helpers
{
    public class MailHelper
    {
        public void SendMail(string fromMail, string toMail, string mailSubject, string mailBody)
        {
            var fromAddress = new MailAddress(fromMail, ConstantStrings.FROM_MAIL_DISPLAY_NAME);
            var toAddress = new MailAddress(toMail, toMail);
            string fromPassword = ConstantStrings.PASSWORD;
            string subject = mailSubject;
            string body = mailBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.IsBodyHtml = true;
                foreach (var item in ConstantStrings.MAIL_ADDRESS_LIST)
                {
                    message.To.Add(item);
                }
                smtp.Send(message);
            }
        }

        public void SendFullReportMail(string fromMail, string toMail, string mailSubject, string mailBody)
        {
            var fromAddress = new MailAddress(fromMail, ConstantStrings.FROM_MAIL_DISPLAY_NAME);
            var toAddress = new MailAddress(toMail, toMail);
            string fromPassword = ConstantStrings.PASSWORD;
            string subject = mailSubject;
            string body = mailBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                message.IsBodyHtml = true;
                foreach (var item in ConstantStrings.TO_COMPLETE_REPORT_MAIL_ADDRESS_LIST)
                {
                    message.To.Add(item);
                }
                smtp.Send(message);
            }
        }
    }
}
