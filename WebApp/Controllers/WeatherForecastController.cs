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
        public ObjectResult CreateNewUser([FromBody] CreateUserDTO input)
        {
            var res = new ServerResponse<User>();
            ValidationResult result = new CreateUserDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var user = new User();
            user.Id = input.Id;
            user.Email = input.Email;
            user.Name = input.Name;
            user.Password = input.Password;

            var newUser = userService.CreateUser(user);
            return Ok(newUser);
        }

    }
}
