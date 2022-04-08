using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseMaterialDTO
{
    public class GetCourseMaterialDTO
    {
        public string CourseUnitId { get; set; }
    }
    public class GetCourseMaterialDTOValidator : AbstractValidator<GetCourseMaterialDTO>
    {
        public GetCourseMaterialDTOValidator()
        {
            RuleFor(x => x.CourseUnitId).NotNull().NotEmpty();
        }
    }
}
