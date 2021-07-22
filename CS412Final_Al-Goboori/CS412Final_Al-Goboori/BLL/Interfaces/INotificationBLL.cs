using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CS412Final_Al_Goboori.BLL.Interfaces
{
    public interface INotificationBLL
    {
        Task SendEmail(string to, string subject, string body, string replyTo = "");
    }
}