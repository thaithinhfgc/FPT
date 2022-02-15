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
        DRAFT = 1,
        WAIT = 2,
        APPROVE = 3,
        DENY = 4
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
        [Required]
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }
        public virtual User Student { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("AdminId")]
        public string AdminId { get; set; }
        public virtual User Admin { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public BlogStatus Status { get; set; }
        public int Vote { get; set; }
    }
}
