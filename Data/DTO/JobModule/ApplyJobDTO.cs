using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule
{
    public class ApplyJobDTO
    {
        public string JobId { get; set; }
    }
    public class ApplyJobDTOValidator : AbstractValidator<ApplyJobDTO>
    {
        public ApplyJobDTOValidator()
        {
            RuleFor(x => x.JobId).NotEmpty().NotNull();
        }
    }
}
