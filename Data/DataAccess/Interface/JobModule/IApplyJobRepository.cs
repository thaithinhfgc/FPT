using Data.Model.JobModule;
using Data.Model.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface.JobModule
{
    public interface IApplyJobRepository
    {
        public void ApplyJob(ApplyJob applyJob);
        public ApplyJob GetApplyJob(string jobId, string applicantId);
        public List<User> GetApplicantByJobId(string jobId);
        public List<Job> GetJobByApplicantId(string applicantId);

    }
}
