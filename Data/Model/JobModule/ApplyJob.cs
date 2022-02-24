using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.JobModule
{
    public class ApplyJob
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }
        [ForeignKey("JobId")]
        public string JobId { get; set; }
        public virtual Job Job { get; set; }
        [ForeignKey("ApplicantId")]
        public string ApplicantId { get; set; }
        public virtual User Applicant { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
