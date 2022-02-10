using Data.DTO;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User CreateUser(User newUser);
        public User GetUserById(string Id);
        public User GetUserByCode(string UserCode);
    }
}
