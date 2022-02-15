using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBlogService
    {
        public Blog CreateDraft(Blog draft);
        public void UpdateBlog(Blog blog);
        public List<Blog> GetDrafts();
        public Blog SubmitBlog(Blog draft);
        public void DeleteDraft(Blog draft);
        public Blog GetDraft(string DraftId);
        public List<Blog> GetBlogs();
        public Blog GetBlog(string BlogId);
        public List<Blog> GetWaitBlogs();
        public Blog GetWaitBlog(string BlogId);
    }
}
