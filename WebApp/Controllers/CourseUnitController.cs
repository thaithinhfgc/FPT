using Data;
using Data.DTO.CourseModule.CourseUnitDTO;
using Data.Model.CourseModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.CourseModule;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseUnitController : ControllerBase
    {
        private readonly ICourseUnitService courseUnitService;
        private readonly ICourseService courseService;

        public CourseUnitController(ICourseUnitService courseUnitService, ICourseService courseService)
        {
            this.courseUnitService = courseUnitService;
            this.courseService = courseService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetCourseUnits([FromBody] GetCourseUnitsDTO input)
        {
            var res = new ServerResponse<List<CourseUnit>>();
            ValidationResult result = new GetCourseUnitsDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var courseUnits = courseUnitService.GetCourseUnits(input.CourseId);
            res.data = courseUnits;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "ADMMIN")]
        public IActionResult CreateCourseUnit([FromBody] CreateCourseUnitDTO input)
        {
            var res = new ServerResponse<CourseUnit>();
            ValidationResult result = new CreateCourseUnitDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var course = courseService.GetCourseById(input.CourseId);
            if (course == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Course");
                return new NotFoundObjectResult(res.getResponse());
            }
            var courseUnit = new CourseUnit
            {
                Id = Guid.NewGuid().ToString(),
                Name = input.Name,
                Course = course,
                CourseId = course.Id,
                CreateDate = DateTime.Now
            };

            courseUnitService.CreateCourseUnit(courseUnit);
            res.data = courseUnit;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Course Unit");
            return new ObjectResult(res.getResponse());
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = "ADMMIN")]
        public IActionResult UpdateCourseUnit([FromBody] UpdateCourseUnitDTO input)
        {
            var res = new ServerResponse<CourseUnit>();
            ValidationResult result = new UpdateCourseUnitDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var courseUnit = courseUnitService.GetCourseUnitById(input.Id);
            if (courseUnit == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Course Unit");
                return new NotFoundObjectResult(res.getResponse());
            }

            courseUnit.Name = input.Name;
            courseUnitService.UpdateCourseUnit(courseUnit);

            res.data = courseUnit;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Course Unit");
            return new ObjectResult(res.getResponse());
        }

        [HttpDelete]
        [Route("")]
        [Authorize(Roles = "ADMMIN")]
        public IActionResult DeleteCourseUnit([FromBody] DeleteCourseUnitDTO input)
        {
            var res = new ServerResponse<CourseUnit>();
            ValidationResult result = new DeleteCourseUnitDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var courseUnit = courseUnitService.GetCourseUnitById(input.Id);
            if (courseUnit == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Course Unit");
                return new NotFoundObjectResult(res.getResponse());
            }

            courseUnitService.DeleteCourseUnit(courseUnit);

            res.data = courseUnit;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_DELETE_SUCCESS, "Course Unit");
            return new ObjectResult(res.getResponse());
        }

    }
}
