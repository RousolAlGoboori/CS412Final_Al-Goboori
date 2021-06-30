using CS412Final_Al_Goboori.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.DAL
{
    public static class UserDAL
    {
        private static List<User> _users = new List<User>() {
            new User() {
                Id = 1,
                First = "Rousol",
                Last = "Al Goboori",
                Email = "ralgoboori@neiu.edu",
                Password = "123"
            }
        };
        public static User GetUser(string email, string password)
        {
        
            return _users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
        public static User Get(string first, string email)
        {

            return _users.FirstOrDefault(x => x.First == first && x.Email == email);
        }

        public static User CreateUser(User user)
        {
            User lastUser = _users.LastOrDefault();
            user.Id = lastUser.Id + 1;
            _users.Add(user);

            return user;
        }
    }
}