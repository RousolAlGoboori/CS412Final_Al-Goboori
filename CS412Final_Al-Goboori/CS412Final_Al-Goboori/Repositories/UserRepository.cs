using CS412Final_Al_Goboori.DAL;
using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.Repositories
{
    public  class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            return UserDAL.CreateUser(user);
        }

        public User Get(string first,string email)
        {
            return UserDAL.Get( first, email);
        }

        public User GetUser(string email, string password)
        {
            return UserDAL.GetUser(email, password);
        }
    }
}