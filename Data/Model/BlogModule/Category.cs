using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.BlogModule
{
    public enum CategoryStatus
    {
        ENABLE = 1,
        DISABLE = 2
    }
    public class Category
    {
        [Key]
        [Required]
        [StringLength(40)]
        public string Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public CategoryStatus Status { get; set; }
    }
}
