using Data.Model.JobModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule.JobDTO
{
    public class UpdateJobDTO
    {
        public string JobId { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string JobRequirement { get; set; }
        public string TimeOfWork { get; set; }
        public double Salary { get; set; }
        public JobType Type { get; set; }
        public JobMajor Major { get; set; }
        public string NumOfApplicant { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class UpdateJobDTOValidator : AbstractValidator<UpdateJobDTO>
    {
        public UpdateJobDTOValidator()
        {
            RuleFor(x => x.JobId).NotEmpty().NotNull();

            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.JobDescription).NotEmpty().NotNull();
            RuleFor(x => x.JobRequirement).NotEmpty().NotNull();
            RuleFor(x => x.NumOfApplicant).NotEmpty().NotNull();
            RuleFor(x => x.Deadline).NotEmpty().NotNull();
            RuleFor(x => x.TimeOfWork).NotEmpty().NotNull();
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Major).IsInEnum();
        }
    }

}
