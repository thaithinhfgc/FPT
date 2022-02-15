using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface
{
    public interface ICommentRepository
    {
        public void CommentBlog(Comment comment);
        public void UpdateComment(Comment comment);
        public void DeleteComment(Comment comment);
        public Comment GetComment(string id);
        public List<Comment> GetCommentsByBlogId(string blogId);
    }
}
