using Data;
using Data.DTO.JobModule.ApplyJobDTO;
using Data.Model.JobModule;
using Data.Model.UserModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.JobModule;
using Service.Interface.UserModule;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplyJobController : ControllerBase
    {
        private readonly IApplyJobService applyJobService;
        private readonly IUserService userService;
        private readonly IJobService jobService;
        public ApplyJobController(IApplyJobService applyJobService, IUserService userService, IJobService jobService)
        {
            this.applyJobService = applyJobService;
            this.userService = userService;
            this.jobService = jobService;
        }

        [HttpGet]
        [Route("getjobbyapplicant")]
        public IActionResult GetJobByApplicant([FromBody] GetJobByApplicantDTO input)
        {
            var res = new ServerResponse<List<Job>>();
            ValidationResult result = new GetJobByApplicantDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var jobs = applyJobService.GetJobByApplicantId(input.ApplicantId);
            res.data = jobs;
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("getapplicantbyjob")]
        public IActionResult GetApplicantByJob([FromBody] GetApplicantByJobDTO input)
        {

            var res = new ServerResponse<List<User>>();
            ValidationResult result = new GetApplicantByJobDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var applicants = applyJobService.GetApplicantByJobId(input.JobId);
            res.data = applicants;
            return new ObjectResult(res.getResponse());
        }


        [HttpPost]
        [Route("")]
        public IActionResult ApplyJob([FromBody] ApplyJobDTO input)
        {
            var res = new ServerResponse<ApplyJob>();
            ValidationResult result = new ApplyJobDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);

            var job = jobService.GetJob(input.JobId);
            if (job == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Job");
                return new NotFoundObjectResult(res.getResponse());
            }

            var applyjob = applyJobService.GetApplyJob(input.JobId, currentUser.Id);
            if (applyjob != null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_EXISTED, "Apply Job");
                return new BadRequestObjectResult(res.getResponse());
            }

            applyjob = new ApplyJob
            {
                Id = Guid.NewGuid().ToString(),
                Job = job,
                JobId = job.Id,
                Applicant = currentUser,
                ApplicantId = currentUser.Id,
                CreateDate = DateTime.Now,
            };

            applyJobService.ApplyJob(applyjob);

            res.data = applyjob;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Apply");
            return new ObjectResult(res.getResponse());
        }
    }
}
