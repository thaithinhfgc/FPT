using Data;
using Data.DTO.CourseModule.CourseMaterialDTO;
using Data.Model.CourseModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.CourseModule;
using Service.Interface.UploadFileModule;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseMaterialController : ControllerBase
    {
        private readonly ICourseMaterialService courseMaterialService;
        private readonly ICourseUnitService courseUnitService;
        private readonly IUploadFileService uploadFileService;
        public CourseMaterialController(ICourseMaterialService courseMaterialService, ICourseUnitService courseUnitService, IUploadFileService uploadFileService)
        {
            this.courseMaterialService = courseMaterialService;
            this.courseUnitService = courseUnitService;
            this.uploadFileService = uploadFileService;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "ADMMIN")]
        public IActionResult CreateCourseMaterial([FromForm] CreateCourseMaterialDTO input)
        {
            var res = new ServerResponse<CourseMaterial>();
            ValidationResult result = new CreateCourseMaterialDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            if (!this.uploadFileService.CheckFileSize(input.File, 25))
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.FILE_TOO_LARGE);
                return new BadRequestObjectResult(res.getResponse());
            }

            var FileUrl = this.uploadFileService.Upload(input.File);

            var courseUnit = courseUnitService.GetCourseUnitById(input.CourseUnitId);
            if (courseUnit == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Course Unit");
                return new NotFoundObjectResult(res.getResponse());
            }


            var courseMaterial = new CourseMaterial
            {
                Id = Guid.NewGuid().ToString(),
                CourseUnit = courseUnit,
                CourseUnitId = input.CourseUnitId,
                File = FileUrl,
                Name = input.Name,
                CreateDate = DateTime.Now,
            };

            courseMaterialService.CreateCourseMaterial(courseMaterial);
            res.data = courseMaterial;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Course Material");
            return new ObjectResult(res.getResponse());
        }


        [HttpDelete]
        [Route("")]
        [Authorize(Roles = "ADMMIN")]
        public IActionResult DeleteCourseMaterial([FromBody] DeleteCourseMaterialDTO input)
        {
            var res = new ServerResponse<CourseMaterial>();
            ValidationResult result = new DeleteCourseMaterialDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var courseMaterial = courseMaterialService.GetCourseMaterial(input.Id);
            if (courseMaterial == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Course Material");
                return new NotFoundObjectResult(res.getResponse());
            }

            courseMaterialService.DeleteCourseMaterial(courseMaterial);
            res.data = courseMaterial;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_DELETE_SUCCESS, "Course Material");
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "ADMMIN")]
        public IActionResult GetCourseMaterial([FromForm] GetCourseMaterialDTO input)
        {
            var res = new ServerResponse<List<CourseMaterial>>();
            ValidationResult result = new GetCourseMaterialDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var courseUnit = courseUnitService.GetCourseUnitById(input.CourseUnitId);
            if (courseUnit == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Course Unit");
                return new NotFoundObjectResult(res.getResponse());
            }

            var courseMaterials = courseMaterialService.GetCourseMaterials(input.CourseUnitId);

            res.data = courseMaterials;

            return new ObjectResult(res.getResponse());
        }
    }
}
