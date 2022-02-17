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

        public List<Tag> GetBlogTags(string blogId)
        {
            return blogTagRepository.GetBlogTags(blogId);
        }

        public void RemoveBlogTag(BlogTag blogTag)
        {
            blogTagRepository.RemoveBlogTag(blogTag);
        }

        public BlogTag GetBlogTag(string blogId, string tagId)
        {
            return blogTagRepository.GetBlogTag(blogId, tagId);
        }
    }
}
