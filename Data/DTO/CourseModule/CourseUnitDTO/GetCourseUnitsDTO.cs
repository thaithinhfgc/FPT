using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseUnitDTO
{
    public class GetCourseUnitsDTO
    {
        public string CourseId { get; set; }
    }

    public class GetCourseUnitsDTOValidator : AbstractValidator<GetCourseUnitsDTO>
    {
        public GetCourseUnitsDTOValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().NotNull();
        }
    }
}
