using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogModule.BlogDTO
{
    public class EditDraftDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
        public string CategoryId { get; set; }
    }

    public class EditDraftDTOValidator : AbstractValidator<EditDraftDTO>
    {
        public EditDraftDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.CategoryId).NotEmpty().NotNull();
        }
    }
}
