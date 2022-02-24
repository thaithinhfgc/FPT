using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.EventModule.EventDTO
{
    public class ParticipantEventDTO
    {
        public string EventId { get; set; }
    }

    public class ParticipantEventDTOValidator : AbstractValidator<ParticipantEventDTO>
    {
        public ParticipantEventDTOValidator()
        {
            RuleFor(x => x.EventId).NotEmpty().NotNull();
        }
    }

}
