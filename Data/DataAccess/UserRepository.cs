using Data.DataAccess.Interface;
using Data.Database;
using Data.Model.UserModule;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Data.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly Context context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserRepository(Context context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public List<User> GetUsers() => context.Users.ToList();

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


        public User GetCurrentUser()
        {
            var identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    Id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value, true)
                };
            }
            return null;
        }

        public User UpdateCurrentUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }
    }
}
