using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.BlogModule
{
    public class Tag
    {
        [Key]
        [Required]
        [StringLength(40)]
        public string Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
