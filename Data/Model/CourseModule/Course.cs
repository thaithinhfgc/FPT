using Data.Model.JobModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.CourseModule
{
    public enum CourseStatus
    {
        ACTIVE = 1,
        INACTIVE = 2,
    }
    public class Course
    {
        [Key]
        [StringLength(40)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("AdminId")]
        public string AdminId { get; set; }
        public virtual User Admin { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public CourseStatus Status { get; set; }
        [Required]
        public JobMajor Major { get; set; }
    }
}
