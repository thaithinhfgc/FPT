using Data.DataAccess.Interface.JobModule;
using Data.Model.JobModule;
using Data.Model.UserModule;
using Service.Interface.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.JobModule
{
    public class ApplyJobService : IApplyJobService
    {
        private readonly IApplyJobRepository applyJobRepository;
        public ApplyJobService(IApplyJobRepository applyJobRepository)
        {
            this.applyJobRepository = applyJobRepository;
        }
        public void ApplyJob(ApplyJob applyJob)
        {
            applyJobRepository.ApplyJob(applyJob);
        }

        public List<User> GetApplicantByJobId(string jobId)
        {
            return applyJobRepository.GetApplicantByJobId(jobId);
        }

        public ApplyJob GetApplyJob(string jobId, string applicantId)
        {
            return applyJobRepository.GetApplyJob(jobId, applicantId);
        }

        public List<Job> GetJobByApplicantId(string applicantId)
        {
            return applyJobRepository.GetJobByApplicantId(applicantId);
        }
    }
}
