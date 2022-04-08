using Data.DataAccess.Interface.CourseModule;
using Data.Database;
using Data.Model.CourseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Implement.CourseModuel
{
    public class CourseUnitRepository : ICourseUnitRepository
    {
        private readonly Context context;
        public CourseUnitRepository(Context context)
        {
            this.context = context;
        }
        public void CreateCourseUnit(CourseUnit courseUnit)
        {
            context.CourseUnits.Add(courseUnit);
            context.SaveChanges();
        }

        public void DeleteCourseUnit(CourseUnit courseUnit)
        {
            context.CourseUnits.Remove(courseUnit);
            context.SaveChanges();
        }


        public CourseUnit GetCourseUnitById(string id)
        {
            var courseUnit = context.CourseUnits.FirstOrDefault(x => x.Id.Equals(id));
            return courseUnit;
        }

        public List<CourseUnit> GetCourseUnits(string courseId)
        {
            var courses = context.CourseUnits.Where(x => x.CourseId.Equals(courseId)).ToList();
            return courses;
        }

        public void UpdateCourseUnit(CourseUnit courseUnit)
        {
            context.CourseUnits.Update(courseUnit);
            context.SaveChanges();
        }
    }
}
