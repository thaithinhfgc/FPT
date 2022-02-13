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
    public enum BlogStatus
    {
        WAIT = 1,
        APPROVE = 2,
        DENY = 3
    }
    public class Blog
    {
        [Key]
        [StringLength(40)]
        [Required]
        public string Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("StudentId")]
        public string StudentId { get; set; }
        public User Student { get; set; }

        [ForeignKey("AdminId")]
        public string AdminId { get; set; }
        public User Admin { get; set; }
        public DateTime CreateDate { get; set; }
        public BlogStatus Status { get; set; }
        public int Vote { get; set; }
    }
}
