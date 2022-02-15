using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.CommentDTO
{
    public class CommentDTO
    {
        public string Content { get; set; }
        public string ParentCommentId { get; set; }
    }

    public class CommentDTOValidator : AbstractValidator<CommentDTO>
    {
        public CommentDTOValidator()
        {
            RuleFor(x => x.Content).NotEmpty().NotNull();
            RuleFor(x => x.ParentCommentId).NotEmpty();
        }
    }
}
