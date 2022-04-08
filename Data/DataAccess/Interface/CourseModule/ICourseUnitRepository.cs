using Data.Model.CourseModule;
using Data.Model.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface.CourseModule
{
    public interface ICourseUnitRepository
    {
        public void CreateCourseUnit(CourseUnit courseUnit);
        public void UpdateCourseUnit(CourseUnit courseUnit);
        public void DeleteCourseUnit(CourseUnit courseUnit);
        public List<CourseUnit> GetCourseUnits(string courseId);
        public CourseUnit GetCourseUnitById(string id);
    }
}
