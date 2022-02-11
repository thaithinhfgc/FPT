using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.UserDTO
{
    public class LoginUserDTO
    {
        public string UserCode { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserDTOValidator : AbstractValidator<LoginUserDTO>
    {
        public LoginUserDTOValidator()
        {
            RuleFor(x => x.UserCode).NotEmpty().NotNull().Length(5, 30);
            RuleFor(x => x.Password).NotEmpty().NotNull().Length(5, 255);
        }
    }
}
