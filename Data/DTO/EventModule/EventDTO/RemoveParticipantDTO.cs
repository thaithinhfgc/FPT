using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.EventModule.EventDTO
{
    public class RemoveParticipantDTO
    {
        public string EventId { get; set; }
    }

    public class RemoveParticipantDTOValidator : AbstractValidator<RemoveParticipantDTO>
    {
        public RemoveParticipantDTOValidator()
        {
            RuleFor(x => x.EventId).NotEmpty().NotNull();
        }
    }
}
