using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class CreateUserDTO
    {
        public string UserCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }

    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(x => x.UserCode).NotEmpty().NotNull().Length(5, 30);
            RuleFor(x => x.Email).NotEmpty().NotNull().Length(5, 255).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull().Length(5, 30);
            RuleFor(x => x.ConfirmPassword).NotEmpty().NotNull().Length(5, 30).Equal(x => x.Password);

        }
    }
}
