using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.JobModule
{
    public class RemoveJobDTO
    {
        public string JobId { get; set; }
    }

    public class RemoveJobDTOValidator : AbstractValidator<RemoveJobDTO>
    {
        public RemoveJobDTOValidator()
        {
            RuleFor(x => x.JobId).NotEmpty().NotNull();
        }
    }
}
