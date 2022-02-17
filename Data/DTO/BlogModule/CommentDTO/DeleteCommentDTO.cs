using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogModule.CommentDTO
{
    public class DeleteCommentDTO
    {
        public string CommentId { get; set; }
    }

    public class DeleteCommentDTOValidator : AbstractValidator<DeleteCommentDTO>
    {
        public DeleteCommentDTOValidator()
        {
            RuleFor(x => x.CommentId).NotEmpty().NotNull();
        }
    }
}
