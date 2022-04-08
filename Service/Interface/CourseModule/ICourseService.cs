using Data.Model.CourseModule;
using Data.Model.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface.CourseModule
{
    public interface ICourseService
    {
        public void CreateCourse(Course course);
        public void UpdateCourse(Course course);
        public List<Course> GetCourses();
        public Course GetCourseByCode(string code);
        public Course GetCourseById(string Id);
        public List<Course> GetCourseByMajor(JobMajor major);
        public (List<Course>, int) SearchCourse(int pageSize, int pageIndex, string search);

    }
}
