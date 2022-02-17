using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.EventModule.EventDTO
{
    public class CancelEventDTO
    {
        public string EventId { get; set; }
    }
    public class CancelEventDTOValidator : AbstractValidator<CancelEventDTO>
    {
        public CancelEventDTOValidator()
        {
            RuleFor(x => x.EventId).NotEmpty().NotNull();
        }
    }
}
