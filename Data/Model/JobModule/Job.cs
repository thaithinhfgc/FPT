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
    public enum JobType
    {
        INTERN = 1,
        JOB = 2,
    }

    public enum JobStatus
    {
        ACTIVE = 1,
        INACTIVE = 2,
    }

    public enum JobMajor
    {
        SE = 1,
        AI = 2,
        IA = 3,
        IOT = 4,
    }
    public class Job
    {
        [Key]
        [StringLength(40)]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [ForeignKey("BusinessId")]
        public string BusinessId { get; set; }
        public virtual User Business { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string JobRequirement { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public string TimeOfWork { get; set; }
        [Required]
        public string NumOfApplicant { get; set; }
        public double Salary { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public JobType Type { get; set; }
        [Required]
        public JobMajor Major { get; set; }
        [Required]
        public JobStatus Status { get; set; }
    }
}
