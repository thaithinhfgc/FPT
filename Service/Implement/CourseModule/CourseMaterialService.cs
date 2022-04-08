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
    public class CourseMaterialService : ICourseMaterialService
    {
        private readonly ICourseMaterialRepository courseMaterialRepository;

        public CourseMaterialService(ICourseMaterialRepository courseMaterialRepository)
        {
            this.courseMaterialRepository = courseMaterialRepository;
        }

        public void CreateCourseMaterial(CourseMaterial courseMaterial)
        {
            courseMaterialRepository.CreateCourseMaterial(courseMaterial);
        }

        public void DeleteCourseMaterial(CourseMaterial courseMaterial)
        {
            courseMaterialRepository.DeleteCourseMaterial(courseMaterial);
        }

        public CourseMaterial GetCourseMaterial(string id)
        {
            return courseMaterialRepository.GetCourseMaterial(id);
        }

        public List<CourseMaterial> GetCourseMaterials(string courseUnitId)
        {
            return courseMaterialRepository.GetCourseMaterials(courseUnitId);
        }

        public void UpdateCourseMaterial(CourseMaterial courseMaterial)
        {
            courseMaterialRepository.UpdateCourseMaterial(courseMaterial);
        }
    }
}
