using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.BlogModule
{
    public class Comment
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }
        public string Content { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("BlogId")]
        public string BlogId { get; set; }
        public virtual Blog BLog { get; set; }

        [ForeignKey("ParentCommentId")]
        public string ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
