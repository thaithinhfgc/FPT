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
    public enum VoteType
    {
        UPVOTE = 1,
        DOWNVOTE = 2
    }
    public class Vote
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("BlogId")]
        public string BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public VoteType VoteType { get; set; }
    }
}
