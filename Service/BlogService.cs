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

        public void SaveDraft(Blog draft)
        {
            blogRepository.SaveDraft(draft);
        }

        public Blog SubmitBlog(Blog draft)
        {
            return blogRepository.SubmitBlog(draft);
        }
        public Blog GetDraft(string DraftId)
        {
            return blogRepository.GetDraft(DraftId);
        }
    }
}
