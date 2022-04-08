using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule.ApplyJobDTO
{
    public class GetJobByApplicantDTO
    {
        public string ApplicantId { get; set; }
    }

    public class GetJobByApplicantDTOValidator : AbstractValidator<GetJobByApplicantDTO>
    {
        public GetJobByApplicantDTOValidator()
        {
            RuleFor(x => x.ApplicantId).NotEmpty().NotNull();
        }
    }
}
