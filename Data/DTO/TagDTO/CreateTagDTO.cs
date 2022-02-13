using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.TagDTO
{
    public class CreateTagDTO
    {
        public string Name { get; set; }
    }

    public class CreateTagDTOValidator : AbstractValidator<CreateTagDTO>
    {
        public CreateTagDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }

}
