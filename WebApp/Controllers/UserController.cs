using Data;
using Data.DTO.UserModule.UserDTO;
using Data.Model.UserModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Service.Interface.UploadFileModule;
using Service.Interface.UserModule;
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
        private readonly IUploadFileService uploadFileService;
        public UserController(IUserService userService, IUploadFileService uploadFileService)
        {
            this.userService = userService;
            this.uploadFileService = uploadFileService;
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
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Profile");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Authorize]
        [Route("avatar")]
        public IActionResult UpdateUserAvatar([FromForm] UpdateUserAvatarDTO input)
        {
            var res = new ServerResponse<User>();
            ValidationResult result = new UpdateUserAvatarDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.uploadFileService.CheckFileSize(input.Avatar, 5))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.FILE_TOO_LARGE);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.uploadFileService.CheckFileExtension(input.Avatar, new string[] { "jpg", "png", "jpeg", "gif", "tiff" }))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.FILE_WRONG_EXTENSION);
                return new BadRequestObjectResult(res.getResponse());
            }

            var avatarUrl = this.uploadFileService.Upload(input.Avatar);
            var user = userService.GetUserById(userService.GetCurrentUser().Id);
            user.Avatar = avatarUrl;
            userService.UpdateCurrentUser(user);
            res.data = user;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Avatar");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Authorize]
        [Route("cv")]
        public IActionResult UploadCV([FromForm] UploadCVDTO input)
        {
            var res = new ServerResponse<User>();
            ValidationResult result = new UploadCVDTOValidator().Validate(input);

            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.uploadFileService.CheckFileSize(input.CV, 10))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.FILE_TOO_LARGE);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.uploadFileService.CheckFileExtension(input.CV, new string[] { "jpg", "png", "jpeg", "gif", "tiff", "pdf", "doc", "docx" }))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.FILE_WRONG_EXTENSION);
                return new BadRequestObjectResult(res.getResponse());
            }

            var CVUrl = this.uploadFileService.Upload(input.CV);
            var user = userService.GetUserById(userService.GetCurrentUser().Id);
            user.CV = CVUrl;
            userService.UpdateCurrentUser(user);
            res.data = user;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "CV");
            return new ObjectResult(res.getResponse());
        }

    }
}
