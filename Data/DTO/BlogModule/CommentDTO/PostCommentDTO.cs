using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogModule.CommentDTO
{
    public class PostCommentDTO
    {
        public string Content { get; set; }
        public string BlogId { get; set; }
        public string ParentCommentId { get; set; }
    }

    public class PostCommentDTOValidator : AbstractValidator<PostCommentDTO>
    {
        public PostCommentDTOValidator()
        {
            RuleFor(x => x.Content).NotEmpty().NotNull();
            RuleFor(x => x.BlogId).NotEmpty().NotNull();
        }
    }
}
