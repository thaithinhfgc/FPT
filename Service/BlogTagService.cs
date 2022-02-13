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
    public class BlogTagService : IBlogTagService
    {
        private readonly IBlogTagRepository blogTagRepository;
        public BlogTagService(IBlogTagRepository blogTagRepository)
        {
            this.blogTagRepository = blogTagRepository;
        }
        public void AddBlogTag(BlogTag blogTag)
        {
            blogTagRepository.AddBlogTag(blogTag);
        }

        public List<Tag> GetBlogTag(string blogId)
        {
            return blogTagRepository.GetBlogTag(blogId);
        }

        public void RemoveBlogTag(BlogTag blogTag)
        {
            blogTagRepository.RemoveBlogTag(blogTag);
        }
    }
}
