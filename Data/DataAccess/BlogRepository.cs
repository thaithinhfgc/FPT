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

        public void SaveDraft(Blog draft)
        {
            context.Blogs.Update(draft);
            context.SaveChanges();
        }

        public Blog SubmitBlog(Blog draft)
        {
            context.Blogs.Update(draft);
            context.SaveChanges();
            return draft;
        }
    }
}
