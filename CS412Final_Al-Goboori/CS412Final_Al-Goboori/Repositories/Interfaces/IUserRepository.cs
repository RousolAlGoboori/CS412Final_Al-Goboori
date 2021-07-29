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
       
        User CreateUser(User user);
        bool DoesUserExistByEmail(string email);
        List<User> GetUsers(List<long> userIds);
        
    }
}