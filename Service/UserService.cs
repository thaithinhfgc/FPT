using Data.DataAccess;
using Data.DataAccess.Interface;
using Data.DTO;
using Data.Model.UserModule;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }


        public User GetUserById(string Id)
        {
            return userRepository.GetUserById(Id);
        }

        public User GetUserByCode(string UserCode)
        {
            return userRepository.GetUserByCode(UserCode);
        }


        public User GetCurrentUser()
        {
            return userRepository.GetCurrentUser();
        }

        public User UpdateCurrentUser(User user)
        {
            return userRepository.UpdateCurrentUser(user);
        }
    }
}
