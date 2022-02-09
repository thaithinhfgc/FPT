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
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().Length(5, 20);
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(5, 20);
            RuleFor(x => x.Password).NotEmpty().NotNull().Length(5, 20);
            RuleFor(x => x.Email).NotEmpty().NotNull().Length(5, 20).EmailAddress();
        }
    }
}
