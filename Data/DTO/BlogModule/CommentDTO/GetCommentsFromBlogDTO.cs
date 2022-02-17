using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogModule.CommentDTO
{
    public class GetCommentsFromBlogDTO
    {
        public string BlogId { get; set; }
    }

    public class GetCommentsFromBlogDTOValidator : AbstractValidator<GetCommentsFromBlogDTO>
    {
        public GetCommentsFromBlogDTOValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().NotNull();
        }
    }
}
