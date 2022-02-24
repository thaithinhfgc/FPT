using Data.DataAccess.Interface.JobModule;
using Data.Database;
using Data.Model.JobModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.JobModule
{
    public class ApplyJobRepository : IApplyJobRepository
    {

        private readonly Context context;
        public ApplyJobRepository(Context context)
        {
            this.context = context;
        }
        public void ApplyJob(ApplyJob applyJob)
        {
            context.ApplyJobs.Add(applyJob);
            context.SaveChanges();
        }

        public List<User> GetApplicantByJobId(string jobId)
        {
            var applicants = new List<User>();
            var applyJobs = context.ApplyJobs.Where(x => x.JobId.Equals(jobId)).ToList();
            foreach (var applyJob in applyJobs)
            {
                applicants.Add(context.Users.FirstOrDefault(x => x.Id.Equals(applyJob.ApplicantId)));
            }
            return applicants;
        }

        public ApplyJob GetApplyJob(string jobId, string applicantId)
        {
            var applyJob = context.ApplyJobs.FirstOrDefault(x => x.JobId.Equals(jobId) && x.ApplicantId.Equals(applicantId));
            return applyJob;
        }

        public List<Job> GetJobByApplicantId(string applicantId)
        {
            var jobs = new List<Job>();
            var applyJobs = context.ApplyJobs.Where(x => x.ApplicantId.Equals(applicantId)).ToList();
            foreach (var applyJob in applyJobs)
            {
                jobs.Add(context.Jobs.FirstOrDefault(x => x.Id.Equals(applyJob.JobId)));
            }
            return jobs;
        }


    }
}
