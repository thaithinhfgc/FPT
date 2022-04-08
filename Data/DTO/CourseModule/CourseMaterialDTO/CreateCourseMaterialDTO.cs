using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseMaterialDTO
{
    public class CreateCourseMaterialDTO
    {
        public string Name { get; set; }
        public string CourseUnitId { get; set; }
        public IFormFile File { get; set; }
    }

    public class CreateCourseMaterialDTOValidator : AbstractValidator<CreateCourseMaterialDTO>
    {
        public CreateCourseMaterialDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.CourseUnitId).NotNull().NotEmpty();
            RuleFor(x => x.File).NotNull();
        }
    }
}
