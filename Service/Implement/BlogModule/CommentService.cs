using Data.DataAccess.Interface.BlogModule;
using Data.Model.BlogModule;
using Service.Interface.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.BlogModule
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void PostComment(Comment comment)
        {
            commentRepository.PostComment(comment);
        }

        public void DeleteComment(Comment comment)
        {
            commentRepository.DeleteComment(comment);
        }

        public Comment GetComment(string id)
        {
            return commentRepository.GetComment(id);
        }

        public List<Comment> GetCommentsFromBlog(string blogId)
        {
            return commentRepository.GetCommentsFromBlog(blogId);
        }

        public void UpdateComment(Comment comment)
        {
            commentRepository.UpdateComment(comment);
        }
    }
}
