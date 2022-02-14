using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogTagDTO
{
    public class AddBlogTagDTO
    {
        public string BlogId { get; set; }
        public string TagName { get; set; }
    }

    public class AddBlogTagDTOValidator : AbstractValidator<AddBlogTagDTO>
    {
        public AddBlogTagDTOValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().NotNull();
            RuleFor(x => x.TagName).NotEmpty().NotNull();
        }
    }
}
