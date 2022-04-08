using Data;
using Data.DTO.JobModule.JobDTO;
using Data.Model.JobModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.JobModule;
using Service.Interface.UserModule;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;
        private readonly IUserService userService;

        public JobController(IJobService jobService, IUserService userService)
        {
            this.jobService = jobService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetJobs()
        {
            var res = new ServerResponse<List<Job>>();
            var jobs = jobService.GetJobs();
            res.data = jobs;
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("major")]
        public IActionResult GetJobByMajor([FromBody] GetJobByMajorDTO input)
        {
            var res = new ServerResponse<List<Job>>();
            ValidationResult result = new GetJobByMajorDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var jobs = jobService.GetJobByMajor(input.Major);
            res.data = jobs;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateJob([FromBody] CreateJobDTO input)
        {
            var res = new ServerResponse<Job>();
            ValidationResult result = new CreateJobDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var business = userService.GetUserById(userService.GetCurrentUser().Id);

            var job = new Job
            {
                Id = Guid.NewGuid().ToString(),
                Title = input.Title,
                Business = business,
                BusinessId = business.Id,
                JobDescription = input.JobDescription,
                JobRequirement = input.JobRequirement,
                Deadline = input.Deadline,
                TimeOfWork = input.TimeOfWork,
                NumOfApplicant = input.NumOfApplicant,
                Salary = input.Salary,
                Type = input.Type,
                Major = input.Major,
                Status = JobStatus.ACTIVE,
                CreateDate = DateTime.Now,
            };

            jobService.CreateJob(job);

            res.data = job;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Job");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateJob([FromBody] UpdateJobDTO input)
        {
            var res = new ServerResponse<Job>();
            ValidationResult result = new UpdateJobDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var job = jobService.GetJob(input.JobId);
            if (job == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Job");
                return new NotFoundObjectResult(res.getResponse());
            }

            job.Title = input.Title;
            job.JobDescription = input.JobDescription;
            job.JobRequirement = input.JobRequirement;
            job.Deadline = input.Deadline;
            job.TimeOfWork = input.TimeOfWork;
            job.NumOfApplicant = input.NumOfApplicant;
            job.Salary = input.Salary;
            job.Type = input.Type;
            job.Major = input.Major;

            jobService.UpdateJob(job);
            res.data = job;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Job");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        [Route("")]
        public IActionResult RemoveJob([FromBody] RemoveJobDTO input)
        {
            var res = new ServerResponse<Job>();
            ValidationResult result = new RemoveJobDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var job = jobService.GetJob(input.JobId);
            if (job == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Job");
                return new NotFoundObjectResult(res.getResponse());
            }

            job.Status = JobStatus.INACTIVE;
            jobService.UpdateJob(job);
            res.data = job;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_DELETE_SUCCESS, "Job");
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("business")]
        public IActionResult GetJobByBusiness([FromBody] GetJobByBusinessDTO input)
        {
            var res = new ServerResponse<List<Job>>();
            ValidationResult result = new GetJobByBusinessDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var jobs = jobService.GetJobByBusinessId(input.BusinessId);
            res.data = jobs;
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchJob(int pageSize, int pageIndex, string search)
        {
            IDictionary<string, object> dataRes = new Dictionary<string, object>();
            ServerResponse<IDictionary<string, object>> res = new ServerResponse<IDictionary<string, object>>();
            if (search == null)
            {
                search = "";
            }
            var (jobs, total) = jobService.SearchJob(pageSize, pageIndex, search);
            dataRes.Add("jobs", jobs);
            dataRes.Add("total", total);
            res.data = dataRes;
            return new ObjectResult(res.getResponse());
        }
    }
}
