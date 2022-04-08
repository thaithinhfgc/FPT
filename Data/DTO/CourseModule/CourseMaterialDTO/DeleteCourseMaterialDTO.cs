using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseMaterialDTO
{
    public class DeleteCourseMaterialDTO
    {
        public string Id { get; set; }
    }
    public class DeleteCourseMaterialDTOValidator : AbstractValidator<DeleteCourseMaterialDTO>
    {
        public DeleteCourseMaterialDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
