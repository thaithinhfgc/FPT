using Data.Model.JobModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CourseModule.CourseDTO
{
    public class UpdateCourseDTO
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public JobMajor Major { get; set; }
    }
    public class UpdateCourseDTOValidator : AbstractValidator<UpdateCourseDTO>
    {
        public UpdateCourseDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Code).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Major).NotEmpty().NotNull();
        }
    }
}
