using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.CourseModule
{
    public class CourseMaterial
    {
        [Key]
        [StringLength(40)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string File { get; set; }
        [ForeignKey("CourseUnitId")]
        public string CourseUnitId { get; set; }
        public virtual CourseUnit CourseUnit { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
