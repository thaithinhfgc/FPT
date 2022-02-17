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
    public class TagRepository : ITagRepository
    {
        private readonly Context context;
        public TagRepository(Context context)
        {
            this.context = context;
        }
        public void CreateTag(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
        }
        public void ClearTag()
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetAllTags()
        {
            List<Tag> tags = context.Tags.ToList();
            return tags;
        }

        public List<Tag> SearchTags(string search)
        {
            List<Tag> tags = context.Tags.Where(x => x.Name.Contains(search)).ToList();
            return tags;
        }

        public Tag GetTagByName(string name)
        {
            Tag tag = context.Tags.FirstOrDefault(x => x.Name.Equals(name));
            return tag;
        }


    }
}
