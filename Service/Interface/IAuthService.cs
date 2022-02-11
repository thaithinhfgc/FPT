using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAuthService
    {
        public User CreateUser(User newUser);

        public string GenerateToken(User user);
    }
}
