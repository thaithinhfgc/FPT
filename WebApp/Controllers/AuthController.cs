using Data;
using Data.DTO.UserDTO;
using Data.Model.UserModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult CreateNewUser([FromBody] CreateUserDTO input)
        {
            var res = new ServerResponse<User>();
            ValidationResult result = new CreateUserDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var _user = userService.GetUserByCode(input.UserCode);
            if (_user != null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_EXISTED, "User Code");
                return new BadRequestObjectResult(res.getResponse());
            }
            var user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.UserCode = input.UserCode;
            user.Email = input.Email;
            user.Password = input.Password;
            user.Role = UserRole.STUDENT;
            user.Status = UserStatus.ACTIVE;
            user.CreateDate = DateTime.Now;

            var newUser = authService.CreateUser(user);
            res.data = newUser;
            return new ObjectResult(res.getResponse());
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromBody] LoginUserDTO input)
        {
            var res = new ServerResponse<string>();
            ValidationResult result = new LoginUserDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            var user = userService.GetUserByCode(input.UserCode);
            if (user == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_LOGIN_FAIL);
                return new BadRequestObjectResult(res.getResponse());
            }

            //       if (!UserService.ComparePassword(user.Password, input.Password))
            //       {
            //           res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_LOGIN_FAIL);
            //            return new BadRequestObjectResult(res.getResponse());
            //       }

            string token = authService.GenerateToken(user);

            res.data = token;
            return new ObjectResult(res.getResponse());
        }
    }
}
