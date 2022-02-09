using Data.DTO;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface
{
    public interface IUserRepository
    {

        public List<User> GetUsers();
        public User CreateUser(User newUser);

        public User GetUserById(string Id);
    }
}
