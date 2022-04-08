using Data.DataAccess.Interface.JobModule;
using Data.Database;
using Data.Model.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.JobModule
{
    public class JobRepository : IJobRepository
    {
        private readonly Context context;
        public JobRepository(Context context)
        {
            this.context = context;
        }
        public void CreateJob(Job job)
        {
            context.Jobs.Add(job);
            context.SaveChanges();
        }

        public Job GetJob(string jobId)
        {
            var job = context.Jobs.FirstOrDefault(x => x.Id.Equals(jobId));
            return job;
        }

        public List<Job> GetJobByMajor(JobMajor jobMajor)
        {
            var jobs = context.Jobs.Where(x => x.Major == jobMajor && x.Status == JobStatus.ACTIVE).ToList();
            return jobs;
        }

        public List<Job> GetJobs()
        {
            var jobs = context.Jobs.Where(x => x.Status == JobStatus.ACTIVE).ToList();
            return jobs;
        }


        public void UpdateJob(Job job)
        {
            context.Jobs.Update(job);
            context.SaveChanges();
        }

        public List<Job> GetJobByBusinessId(string businessId)
        {
            var jobs = context.Jobs.Where(x => x.BusinessId.Equals(businessId)).ToList();
            return jobs;
        }
        public (List<Job>, int) SearchJob(int pageSize, int pageIndex, string search)
        {
            var list = context.Jobs.Where(x => x.Business.Name.Contains(search) || x.Title.Contains(search)).ToList();
            var count = list.Count;
            var pagelist = list.Take((pageIndex + 1) * pageSize).Skip(pageIndex * pageSize).ToList();


            return (pagelist, count);
        }
    }
}
