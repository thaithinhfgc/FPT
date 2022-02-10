using Data.DataAccess.Interface;
using Data.Database;
using Data.DTO;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly Context context;
        public UserRepository(Context context)
        {
            this.context = context;
        }
        public List<User> GetUsers() => context.Users.ToList();
        public User CreateUser(User newUser)
        {
            context.Users.Add(newUser);
            this.context.SaveChanges();
            return newUser;
        }

        public User GetUserById(string Id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id.Equals(Id));
            return user;
        }

        public User GetUserByCode(string UserCode)
        {
            var user = context.Users.FirstOrDefault(x => x.UserCode.Equals(UserCode));
            return user;
        }
    }
}
