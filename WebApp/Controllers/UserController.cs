using Data;
using Data.DTO.UserDTO;
using Data.Model.UserModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }



        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        [Route("all")]
        public IActionResult GetAllUsers()
        {
            var res = new ServerResponse<List<User>>();
            var listUser = userService.GetUsers();
            res.data = listUser;
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("profile")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var res = new ServerResponse<User>();
            var user = userService.GetUserById(userService.GetCurrentUser().Id);
            res.data = user;
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Authorize]
        [Route("update")]
        public IActionResult UpdateCurrentUser([FromBody] UpdateCurrentUserDTO input)
        {
            var res = new ServerResponse<User>();
            ValidationResult result = new UpdateCurrentUserDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }
            var user = userService.GetUserById(userService.GetCurrentUser().Id);
            user.Name = input.Name;
            user.Phone = input.Phone;
            userService.UpdateCurrentUser(user);
            res.data = user;
            return new ObjectResult(res.getResponse());
        }

    }
}
