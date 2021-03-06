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
    public class BlogTagRepository : IBlogTagRepository
    {
        private readonly Context context;
        public BlogTagRepository(Context context)
        {
            this.context = context;
        }
        public void AddBlogTag(BlogTag blogTag)
        {
            context.BlogTags.Add(blogTag);
            context.SaveChanges();
        }

        public void RemoveBlogTag(BlogTag blogTag)
        {
            context.BlogTags.Remove(blogTag);
            context.SaveChanges();
        }

        public List<Tag> GetBlogTags(string blogId)
        {
            List<Tag> tags = new List<Tag>();
            List<BlogTag> blogTags = context.BlogTags.Where(x => x.BlogId.Equals(blogId)).ToList();
            foreach (BlogTag blogTag in blogTags)
            {
                tags.Add(context.Tags.FirstOrDefault(x => x.Id.Equals(blogTag.TagId)));
            }
            return tags;
        }

        public BlogTag GetBlogTag(string blogId, string tagId)
        {
            var blogTag = context.BlogTags.FirstOrDefault(x => x.BlogId.Equals(blogId) && x.Equals(tagId));
            return blogTag;
        }
    }
}
