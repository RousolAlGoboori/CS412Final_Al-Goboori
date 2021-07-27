using CS412Final_Al_Goboori.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using CS412Final_Al_Goboori.Repositories;
using System.Threading.Tasks;

namespace CS412Final_Al_Goboori.BLL
{
    public class NotificationBLL : INotificationBLL
    {
        private readonly IError _error;
        public NotificationBLL()
        {
            _error = new Error();
        }
        public async Task SendEmail(string to, string subject, string body, string replyTo = "")
        {
           
            using (MailMessage message = new MailMessage())
            {
                message.To.Add(to.Trim());
                message.From = new MailAddress(message.From.Address, "Order Through Me");
                message.Subject = subject;
                if (string.IsNullOrWhiteSpace(replyTo) == false)
                {
                    message.ReplyToList.Add(replyTo.Trim());
                }
                message.Body = body;
                message.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient())
                {
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        _error.Log(ex);
                    }
                }
            }
        }
    }
}