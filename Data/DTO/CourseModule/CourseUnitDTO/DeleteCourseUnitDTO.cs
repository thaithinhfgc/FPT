using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseUnitDTO
{
    public class DeleteCourseUnitDTO
    {
        public string Id { get; set; }
    }

    public class DeleteCourseUnitDTOValidator : AbstractValidator<DeleteCourseUnitDTO>
    {
        public DeleteCourseUnitDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
