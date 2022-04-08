using Data.Model.CourseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.Interface.CourseModule
{
    public interface ICourseMaterialRepository
    {
        public void CreateCourseMaterial(CourseMaterial courseMaterial);
        public void UpdateCourseMaterial(CourseMaterial courseMaterial);
        public void DeleteCourseMaterial(CourseMaterial courseMaterial);
        public CourseMaterial GetCourseMaterial(string id);
        public List<CourseMaterial> GetCourseMaterials(string courseUnitId);
    }
}
