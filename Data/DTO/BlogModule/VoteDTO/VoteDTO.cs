using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogModule.VoteDTO
{
    public class VoteDTO
    {
        public string BlogId { get; set; }
    }

    public class VoteDTOValidator : AbstractValidator<VoteDTO>
    {
        public VoteDTOValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().NotNull();
        }
    }
}
