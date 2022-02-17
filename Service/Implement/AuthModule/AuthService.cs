using Data.DataAccess.Interface.AuthModule;
using Data.Model.UserModule;
using Service.Interface.AuthService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.AuthModule
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public User CreateUser(User newUser)
        {
            return authRepository.CreateUser(newUser);
        }

        public string GenerateToken(User user)
        {
            return authRepository.GenerateToken(user);
        }

    }
}
