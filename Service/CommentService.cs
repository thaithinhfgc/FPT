using Data.DataAccess.Interface;
using Data.Model.BlogModule;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void CommentBlog(Comment comment)
        {
            commentRepository.CommentBlog(comment);
        }

        public void DeleteComment(Comment comment)
        {
            commentRepository.DeleteComment(comment);
        }

        public Comment GetComment(string id)
        {
            return commentRepository.GetComment(id);
        }

        public List<Comment> GetCommentsByBlogId(string blogId)
        {
            return commentRepository.GetCommentsByBlogId(blogId);
        }

        public void UpdateComment(Comment comment)
        {
            commentRepository.UpdateComment(comment);
        }
    }
}
