using Data.Model.BlogModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryStatus Status { get; set; }
    }

    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull().Length(30, 40);
            RuleFor(c => c.Name).NotEmpty().NotNull().Length(1, 20);
            RuleFor(c => c.Status).NotEmpty().NotNull().IsInEnum();
            RuleFor(c => c.Description).NotEmpty().NotNull().Length(1, 255);
        }
    }
}
