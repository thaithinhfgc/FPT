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
    public class EventParticipant
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }
        [ForeignKey("EventId")]
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
        [ForeignKey("PaticipantId")]
        public string PaticipantId { get; set; }
        public virtual User Paticipant { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
