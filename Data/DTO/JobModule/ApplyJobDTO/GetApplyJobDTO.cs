using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule.ApplyJobDTO
{
    public class GetApplyJobDTO
    {
        public string JobId { get; set; }
        public string ApplicantId { get; set; }
    }

    public class GetApplyJobDTOValidator : AbstractValidator<GetApplyJobDTO>
    {
        public GetApplyJobDTOValidator()
        {
            RuleFor(x => x.JobId).NotEmpty().NotNull();
            RuleFor(x => x.ApplicantId).NotEmpty().NotNull();
        }
    }
}
