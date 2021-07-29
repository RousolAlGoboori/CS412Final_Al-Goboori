using CS412Final_Al_Goboori.BLL.Interfaces;
using CS412Final_Al_Goboori.Domain;
using CS412Final_Al_Goboori.Repositories;
using CS412Final_Al_Goboori.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Al_Goboori.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserRepository _userRepository;
        public UserBLL()
        {
            _userRepository = new UserRepository();
        }

        public User CreateUser(User user)
        {

            if (_userRepository.DoesUserExistByEmail(user.Email) == false)
            {
                return _userRepository.CreateUser(user);
            }
            return null;
        }

        public User GetUser(string email, string password)
        {
            return _userRepository.GetUser(email, password);
        }

    }
}