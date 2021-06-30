using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string email, string password);
        User Get(string first,string email);
        User CreateUser(User user);
    }
}