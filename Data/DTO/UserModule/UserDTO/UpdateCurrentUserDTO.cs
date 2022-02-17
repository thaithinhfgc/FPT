using FluentValidation;
using System.Text.RegularExpressions;

namespace Data.DTO.UserModule.UserDTO
{
    public class UpdateCurrentUserDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }

    }

    public class UpdateCurrentUserDTOValidator : AbstractValidator<UpdateCurrentUserDTO>
    {
        public UpdateCurrentUserDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(5, 30);
            RuleFor(x => x.Phone).NotEmpty().NotNull().Length(5, 20).Matches(new Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b")); ;

        }
    }
}
