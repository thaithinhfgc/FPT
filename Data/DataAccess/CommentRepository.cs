using Data.DataAccess.Interface;
using Data.Database;
using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Context context;
        public CommentRepository(Context context)
        {
            this.context = context;
        }
        public void CommentBlog(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            context.Comments.Remove(comment);
            context.SaveChanges();
        }

        public Comment GetComment(string commentId)
        {
            var comment = context.Comments.FirstOrDefault(x => x.Id == commentId);
            return comment;
        }

        public List<Comment> GetCommentsByBlogId(string blogId)
        {
            var comments = context.Comments.Where(x => x.BLog.Equals(blogId)).ToList();
            return comments;
        }

        public void UpdateComment(Comment comment)
        {
            context.Comments.Update(comment);
            context.SaveChanges();
        }
    }
}
