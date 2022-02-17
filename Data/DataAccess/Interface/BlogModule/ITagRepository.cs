using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface.BlogModule
{
    public interface ITagRepository
    {
        public void CreateTag(Tag tag);
        public void ClearTag();
        public List<Tag> GetAllTags();
        public List<Tag> SearchTags(string search);
        public Tag GetTagByName(string name);

    }
}
