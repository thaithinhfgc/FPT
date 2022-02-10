using Data;
using Data.DTO;
using Data.Model;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserService userService;
        public WeatherForecastController(IUserService userService)
        {
            this.userService = userService;
        }



        [HttpGet]
        [Route("user")]
        public IActionResult GetAllUsers()
        {
            var listUser = userService.GetUsers();
            return Ok(listUser);
        }

        [HttpPost]
        [Route("user")]
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

            var newUser = userService.CreateUser(user);
            res.data = newUser;
            return new ObjectResult(res.getResponse());
        }

    }
}
