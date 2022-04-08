using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule.ApplyJobDTO
{
    public class GetApplicantByJobDTO
    {
        public string JobId { get; set; }
    }

    public class GetApplicantByJobDTOValidator : AbstractValidator<GetApplicantByJobDTO>
    {
        public GetApplicantByJobDTOValidator()
        {
            RuleFor(x => x.JobId).NotEmpty().NotNull();
        }
    }
}
