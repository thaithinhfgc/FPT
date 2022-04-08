using Data.DataAccess.Interface.CourseModule;
using Data.Database;
using Data.Model.CourseModule;
using Data.Model.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.CourseModuel
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Context context;

        public CourseRepository(Context context)
        {
            this.context = context;
        }

        public void CreateCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }


        public Course GetCourseByCode(string code)
        {
            var course = context.Courses.FirstOrDefault(x => x.Code.Equals(code));
            return course;
        }

        public Course GetCourseById(string Id)
        {
            var course = context.Courses.FirstOrDefault(x => x.Id.Equals(Id));
            return course;
        }

        public List<Course> GetCourseByMajor(JobMajor major)
        {
            var courses = context.Courses.Where(x => x.Major == major).ToList();
            return courses;
        }

        public List<Course> GetCourses()
        {
            var courses = context.Courses.ToList();
            return courses;
        }

        public void UpdateCourse(Course course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
        }

        public (List<Course>, int) SearchCourse(int pageSize, int pageIndex, string search)
        {
            var list = context.Courses.Where(x => x.Name.Contains(search) || x.Code.Contains(search)).ToList();
            var count = list.Count;
            var pagelist = list.Take((pageIndex + 1) * pageSize).Skip(pageIndex * pageSize).ToList();


            return (pagelist, count);
        }

    }
}
