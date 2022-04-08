using Data.DataAccess.Interface.CourseModule;
using Data.Model.CourseModule;
using Data.Model.JobModule;
using Service.Interface.CourseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.CourseModule
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public void CreateCourse(Course course)
        {
            courseRepository.CreateCourse(course);
        }

        public Course GetCourseByCode(string code)
        {
            return courseRepository.GetCourseByCode(code);
        }

        public Course GetCourseById(string Id)
        {
            return courseRepository.GetCourseById(Id);
        }

        public List<Course> GetCourseByMajor(JobMajor major)
        {
            return courseRepository.GetCourseByMajor(major);
        }

        public List<Course> GetCourses()
        {
            return courseRepository.GetCourses();
        }

        public (List<Course>, int) SearchCourse(int pageSize, int pageIndex, string search)
        {
            return courseRepository.SearchCourse(pageSize, pageIndex, search);
        }

        public void UpdateCourse(Course course)
        {
            courseRepository.UpdateCourse(course);
        }
    }
}
