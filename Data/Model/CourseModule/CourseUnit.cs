using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.CourseModule
{
    public class CourseUnit
    {
        [Key]
        [StringLength(40)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
