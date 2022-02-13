using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogTagDTO
{
    public class GetBlogTagDTO
    {
        public string BlogId { get; set; }
    }

    public class GetBlogTagDTOValidator : AbstractValidator<GetBlogTagDTO>
    {
        public GetBlogTagDTOValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().NotNull();
        }
    }


}
