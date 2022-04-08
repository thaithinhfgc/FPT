using Data;
using Data.DTO.CourseModule.CourseDTO;
using Data.Model.CourseModule;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.CourseModule;
using Service.Interface.UserModule;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly IUserService userService;

        public CourseController(ICourseService courseService, IUserService userService)
        {
            this.courseService = courseService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetCourses()
        {
            var res = new ServerResponse<List<Course>>();
            var courses = courseService.GetCourses();
            res.data = courses;
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("major")]
        public IActionResult GetCourseByMajor([FromBody] GetCourseByMajorDTO input)
        {
            var res = new ServerResponse<List<Course>>();
            ValidationResult result = new GetCourseByMajorDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var courses = courseService.GetCourseByMajor(input.Major);
            res.data = courses;
            return new ObjectResult(res.getResponse());
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateCourse([FromBody] CreateCourseDTO input)
        {
            var res = new ServerResponse<Course>();
            ValidationResult result = new CreateCourseDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var course = courseService.GetCourseByCode(input.Code);
            if (course != null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_EXISTED, "Course Name");
                return new BadRequestObjectResult(res.getResponse());
            }

            var currentUser = userService.GetUserById(userService.GetCurrentUser().Id);

            course = new Course
            {
                Id = Guid.NewGuid().ToString(),
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Admin = currentUser,
                AdminId = currentUser.Id,
                Status = CourseStatus.ACTIVE,
                Major = input.Major,
                CreateDate = DateTime.Now,
            };

            courseService.CreateCourse(course);
            res.data = course;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_ADD_SUCCESS, "Course");
            return new ObjectResult(res.getResponse());

        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        [Route("")]
        public IActionResult UpdateCourse([FromBody] UpdateCourseDTO input)
        {
            var res = new ServerResponse<Course>();
            ValidationResult result = new UpdateCourseDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                res.mapDetails(result);
                return new BadRequestObjectResult(res.getResponse());
            }

            var course = courseService.GetCourseById(input.Id);
            if (course == null)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_NOT_FOUND, "Course");
                return new NotFoundObjectResult(res.getResponse());
            }

            course = courseService.GetCourseByCode(input.Code);
            if (course != null && course.Id != input.Id)
            {
                res.setErrorMessage(CustomValidator.ErrorMessageKey.ERROR_EXISTED, "Course");
                return new BadRequestObjectResult(res.getResponse());
            }

            course.Code = input.Code;
            course.Name = input.Name;
            course.Description = input.Description;
            course.Major = input.Major;

            courseService.UpdateCourse(course);
            res.data = course;
            res.setMessage(CustomValidator.MessageKey.MESSAGE_UPDATE_SUCCESS, "Course");
            return new ObjectResult(res.getResponse());
        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchCourse(int pageSize, int pageIndex, string search)
        {
            IDictionary<string, object> dataRes = new Dictionary<string, object>();
            ServerResponse<IDictionary<string, object>> res = new ServerResponse<IDictionary<string, object>>();
            if (search == null)
            {
                search = "";
            }
            var (courses, total) = courseService.SearchCourse(pageSize, pageIndex, search);
            dataRes.Add("courses", courses);
            dataRes.Add("total", total);
            res.data = dataRes;
            return new ObjectResult(res.getResponse());
        }

    }
}
