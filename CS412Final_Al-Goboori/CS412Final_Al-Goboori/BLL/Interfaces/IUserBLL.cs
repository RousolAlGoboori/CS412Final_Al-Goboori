using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.BLL.Interfaces
{
    public interface IUserBLL
    {
        User GetUser(string email, string password);
     
        User CreateUser(User user);
    }
}