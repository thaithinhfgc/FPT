using Data.Model.JobModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.JobModule
{
    public interface IApplyJobService
    {
        public void ApplyJob(ApplyJob applyJob);
        public ApplyJob GetApplyJob(string jobId, string applicantId);
        public List<User> GetApplicantByJobId(string jobId);
        public List<Job> GetJobByApplicantId(string applicantId);
    }
}
