using Data.DataAccess.Interface.BlogModule;
using Data.Database;
using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.BlogModule
{
    public class BlogRepository : IBlogRepository
    {
        private readonly Context context;
        public BlogRepository(Context context)
        {
            this.context = context;
        }
        public Blog CreateDraft(Blog draft)
        {
            context.Blogs.Add(draft);
            context.SaveChanges();
            return draft;
        }

        public void DeleteDraft(Blog draft)
        {
            context.Blogs.Remove(draft);
            context.SaveChanges();

        }

        public Blog GetDraft(string DraftId)
        {
            var draft = context.Blogs.FirstOrDefault(x => x.Id == DraftId);
            return draft;
        }

        public List<Blog> GetDrafts()
        {
            var drafts = context.Blogs.Where(x => x.Status == BlogStatus.DRAFT).ToList();
            return drafts;
        }

        public void UpdateBlog(Blog blog)
        {
            context.Blogs.Update(blog);
            context.SaveChanges();
        }

        public Blog SubmitBlog(Blog draft)
        {
            context.Blogs.Update(draft);
            context.SaveChanges();
            return draft;
        }

        public List<Blog> GetBlogs()
        {
            var blogs = context.Blogs.Where(x => x.Status == BlogStatus.APPROVE).ToList();
            return blogs;
        }

        public Blog GetBlog(string blogId)
        {
            var blog = context.Blogs.FirstOrDefault(x => x.Id.Equals(blogId) && x.Status == BlogStatus.APPROVE);
            return blog;
        }

        public List<Blog> GetWaitBlogs()
        {
            var blogs = context.Blogs.Where(x => x.Status == BlogStatus.WAIT).ToList();
            return blogs;
        }

        public Blog GetWaitBlog(string blogId)
        {
            var blog = context.Blogs.FirstOrDefault(x => x.Id == blogId && x.Status == BlogStatus.WAIT);
            return blog;
        }
    }
}
