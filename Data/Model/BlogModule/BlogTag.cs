using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.BlogModule
{

    public class BlogTag
    {
        public string Id { get; set; }

        [ForeignKey("TagId")]
        public string TagId { get; set; }
        public Tag Tag { get; set; }

        [ForeignKey("BlogId")]
        public string BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
