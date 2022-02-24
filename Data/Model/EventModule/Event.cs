using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.EventModule
{
    public enum EventStatus
    {
        UPCOMING = 1,
        ONGOING = 2,
        COMPLETE = 3,
        CANCEL = 4,

    }
    public class Event
    {
        [Key]
        [StringLength(40)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public EventStatus Status { get; set; }

        [ForeignKey("AdminId")]
        public string AdminId { get; set; }
        public virtual User Admin { get; set; }
        [Required]
        [Range(1, 9999)]
        public int NumOfPaticipant { get; set; }
    }
}
