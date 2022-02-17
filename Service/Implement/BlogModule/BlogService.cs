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
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public Blog CreateDraft(Blog draft)
        {
            return blogRepository.CreateDraft(draft);
        }

        public void DeleteDraft(Blog draft)
        {
            blogRepository.DeleteDraft(draft);
        }

        public List<Blog> GetDrafts()
        {
            return blogRepository.GetDrafts();
        }

        public void UpdateBlog(Blog blog)
        {
            blogRepository.UpdateBlog(blog);
        }

        public Blog SubmitBlog(Blog draft)
        {
            return blogRepository.SubmitBlog(draft);
        }
        public Blog GetDraft(string DraftId)
        {
            return blogRepository.GetDraft(DraftId);
        }

        public List<Blog> GetBlogs()
        {
            return blogRepository.GetBlogs();
        }

        public Blog GetBlog(string BlogId)
        {
            return blogRepository.GetBlog(BlogId);
        }

        public List<Blog> GetWaitBlogs()
        {
            return blogRepository.GetWaitBlogs();
        }

        public Blog GetWaitBlog(string blogId)
        {
            return blogRepository.GetWaitBlog(blogId);
        }
    }
}
