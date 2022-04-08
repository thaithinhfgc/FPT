using Data.DataAccess.Interface.JobModule;
using Data.Model.JobModule;
using Service.Interface.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.JobModule
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public void CreateJob(Job job)
        {
            jobRepository.CreateJob(job);
        }

        public Job GetJob(string jobId)
        {
            return jobRepository.GetJob(jobId);
        }

        public List<Job> GetJobByBusinessId(string businessId)
        {
            return jobRepository.GetJobByBusinessId(businessId);
        }

        public List<Job> GetJobByMajor(JobMajor jobMajor)
        {
            return jobRepository.GetJobByMajor(jobMajor);
        }

        public List<Job> GetJobs()
        {
            return jobRepository.GetJobs();
        }

        public void UpdateJob(Job job)
        {
            jobRepository.UpdateJob(job);
        }
        public (List<Job>, int) SearchJob(int pageSize, int pageIndex, string search)
        {
            return jobRepository.SearchJob(pageSize, pageIndex, search);
        }
    }
}
