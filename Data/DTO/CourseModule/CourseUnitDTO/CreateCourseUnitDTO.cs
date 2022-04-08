using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseUnitDTO
{
    public class CreateCourseUnitDTO
    {
        public string Name { get; set; }
        public string CourseId { get; set; }
    }

    public class CreateCourseUnitDTOValidator : AbstractValidator<CreateCourseUnitDTO>
    {
        public CreateCourseUnitDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.CourseId).NotEmpty().NotNull();
        }
    }
}
