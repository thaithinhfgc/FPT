using Data.DTO;
using Data.Model.UserModule;
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
        public User GetUserById(string Id);
        public User GetUserByCode(string Id);
        public User GetCurrentUser();
        public User UpdateCurrentUser(User user);
    }
}
