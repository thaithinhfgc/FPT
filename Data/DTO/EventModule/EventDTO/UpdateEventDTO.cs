using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.EventModule.EventDTO
{
    public class UpdateEventDTO
    {
        public string EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumOfPatitcipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateEventDTOValidator : AbstractValidator<UpdateEventDTO>
    {
        public UpdateEventDTOValidator()
        {
            RuleFor(x => x.EventId).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.NumOfPatitcipant).NotEmpty().NotNull();
            RuleFor(x => x.StartDate).NotEmpty().NotNull();
            RuleFor(x => x.EndDate).NotEmpty().NotNull();
        }
    }
}
