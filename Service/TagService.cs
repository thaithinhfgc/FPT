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
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public void ClearTag()
        {
            tagRepository.ClearTag();
        }

        public void CreateTag(Tag tag)
        {
            tagRepository.CreateTag(tag);
        }

        public List<Tag> GetAllTags()
        {
            return tagRepository.GetAllTags();
        }

        public List<Tag> SearchTags(string search)
        {
            return tagRepository.SearchTags(search);
        }

        public Tag GetTagByName(string name)
        {
            return tagRepository.GetTagByName(name);
        }

    }
}
