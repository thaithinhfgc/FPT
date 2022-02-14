using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogDTO
{
    public class SubmitDraftDTO
    {
        public string Id { get; set; }
    }

    public class SubmitDraftDTOValidator : AbstractValidator<SubmitDraftDTO>
    {
        public SubmitDraftDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
