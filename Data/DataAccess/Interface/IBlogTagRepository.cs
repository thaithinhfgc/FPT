﻿using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface
{
    public interface IBlogTagRepository
    {
        public void AddBlogTag(BlogTag blogTag);
        public void RemoveBlogTag(BlogTag blogTag);
        public List<Tag> GetBlogTag(string blogId);
    }
}