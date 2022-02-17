using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.EventModule.EventDTO
{
    public class GetEventDTO
    {
        public string EventId { get; set; }
    }
    public class GetEventDTOValidator : AbstractValidator<GetEventDTO>
    {
        public GetEventDTOValidator()
        {
            RuleFor(x => x.EventId).NotEmpty().NotNull();
        }
    }
}

