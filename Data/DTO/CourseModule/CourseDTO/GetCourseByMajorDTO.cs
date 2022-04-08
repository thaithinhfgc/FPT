using Data.Model.JobModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseDTO
{
    public class GetCourseByMajorDTO
    {
        public JobMajor Major { get; set; }
    }

    public class GetCourseByMajorDTOValidator : AbstractValidator<GetCourseByMajorDTO>
    {
        public GetCourseByMajorDTOValidator()
        {
            RuleFor(x => x.Major).IsInEnum();
        }
    }
}
