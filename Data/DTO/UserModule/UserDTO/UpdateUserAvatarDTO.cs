using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.UserModule.UserDTO
{
    public class UpdateUserAvatarDTO
    {
        public IFormFile Avatar { get; set; }
    }

    public class UpdateUserAvatarDTOValidator : AbstractValidator<UpdateUserAvatarDTO>
    {
        public UpdateUserAvatarDTOValidator()
        {
            RuleFor(x => x.Avatar).NotNull();
        }
    }
}
