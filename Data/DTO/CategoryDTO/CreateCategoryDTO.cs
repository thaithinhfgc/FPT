using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CategoryDTO
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().Length(1, 20);
            RuleFor(c => c.Description).NotEmpty().NotNull().Length(1, 255);
        }
    }
}
