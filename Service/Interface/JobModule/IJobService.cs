using Data.Model.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.JobModule
{
    public interface IJobService
    {
        public Job GetJob(string jobId);
        public List<Job> GetJobs();
        public List<Job> GetJobByMajor(JobMajor jobMajor);
        public void CreateJob(Job job);
        public void UpdateJob(Job job);
        public List<Job> GetJobByBusinessId(string businessId);

    }
}
