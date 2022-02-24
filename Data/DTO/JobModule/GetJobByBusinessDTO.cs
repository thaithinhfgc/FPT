using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule
{
    public class GetJobByBusinessDTO
    {
        public string BusinessId { get; set; }
    }

    public class GetJobByBusinessDTOValidator : AbstractValidator<GetJobByBusinessDTO>
    {
        public GetJobByBusinessDTOValidator()
        {
            RuleFor(x => x.BusinessId).NotEmpty().NotNull();
        }
    }
}
