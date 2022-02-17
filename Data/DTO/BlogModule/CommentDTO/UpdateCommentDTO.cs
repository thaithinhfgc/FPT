using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.BlogModule.CommentDTO
{
    public class UpdateCommentDTO
    {
        public string CommentId { get; set; }
        public string Content { get; set; }

    }

    public class UpdateCommentDTOValidator : AbstractValidator<UpdateCommentDTO>
    {
        public UpdateCommentDTOValidator()
        {
            RuleFor(x => x.CommentId).NotEmpty().NotNull();
            RuleFor(x => x.Content).NotEmpty().NotNull();
        }
    }
}
