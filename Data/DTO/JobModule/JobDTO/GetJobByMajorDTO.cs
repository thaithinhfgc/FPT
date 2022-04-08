using Data.Model.JobModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule.JobDTO
{
    public class GetJobByMajorDTO
    {
        public JobMajor Major { get; set; }
    }

    public class GetJobByMajorDTOValidator : AbstractValidator<GetJobByMajorDTO>
    {
        public GetJobByMajorDTOValidator()
        {
            RuleFor(x => x.Major).NotEmpty().NotNull();
        }
    }
}
