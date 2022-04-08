using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseUnitDTO
{
    public class UpdateCourseUnitDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCourseUnitDTOValidator : AbstractValidator<UpdateCourseUnitDTO>
    {
        public UpdateCourseUnitDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }

}
