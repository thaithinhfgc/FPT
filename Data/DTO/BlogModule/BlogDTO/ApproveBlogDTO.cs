using Data.Model.BlogModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogModule.BlogDTO
{
    public class ApproveBlogDTO
    {
        public string Id { get; set; }
        public BlogStatus Status { get; set; }
    }

    public class ApproveBlogDTOValidator : AbstractValidator<ApproveBlogDTO>
    {
        public ApproveBlogDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
