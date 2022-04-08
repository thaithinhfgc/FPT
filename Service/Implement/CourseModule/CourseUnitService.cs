using Data.DataAccess.Interface.CourseModule;
using Data.Model.CourseModule;
using Service.Interface.CourseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.CourseModule
{
    public class CourseUnitService : ICourseUnitService
    {
        private readonly ICourseUnitRepository courseUnitRepository;

        public CourseUnitService(ICourseUnitRepository courseUnitRepository)
        {
            this.courseUnitRepository = courseUnitRepository;
        }

        public void CreateCourseUnit(CourseUnit courseUnit)
        {
            courseUnitRepository.CreateCourseUnit(courseUnit);
        }

        public void DeleteCourseUnit(CourseUnit courseUnit)
        {
            courseUnitRepository.DeleteCourseUnit(courseUnit);
        }

        public CourseUnit GetCourseUnitById(string id)
        {
            return courseUnitRepository.GetCourseUnitById(id);
        }

        public List<CourseUnit> GetCourseUnits(string courseId)
        {
            return courseUnitRepository.GetCourseUnits(courseId);
        }

        public void UpdateCourseUnit(CourseUnit courseUnit)
        {
            courseUnitRepository.UpdateCourseUnit(courseUnit);
        }
    }
}
