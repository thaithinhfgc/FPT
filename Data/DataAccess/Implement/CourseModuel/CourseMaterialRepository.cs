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
    public class CourseMaterialRepository : ICourseMaterialRepository
    {
        private readonly Context context;
        public CourseMaterialRepository(Context context)
        {
            this.context = context;
        }
        public void CreateCourseMaterial(CourseMaterial courseMaterial)
        {
            context.CourseMaterials.Add(courseMaterial);
            context.SaveChanges();
        }

        public void DeleteCourseMaterial(CourseMaterial courseMaterial)
        {
            context.CourseMaterials.Remove(courseMaterial);
            context.SaveChanges();
        }

        public CourseMaterial GetCourseMaterial(string id)
        {
            var courseMaterial = context.CourseMaterials.FirstOrDefault(x => x.Id.Equals(id));
            return courseMaterial;
        }

        public List<CourseMaterial> GetCourseMaterials(string courseUnitId)
        {
            var courseMaterials = context.CourseMaterials.Where(x => x.CourseUnitId.Equals(courseUnitId)).ToList();
            return courseMaterials;
        }

        public void UpdateCourseMaterial(CourseMaterial courseMaterial)
        {
            context.CourseMaterials.Update(courseMaterial);
            context.SaveChanges();
        }
    }
}
