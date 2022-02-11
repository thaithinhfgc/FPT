using Data.DataAccess.Interface;
using Data.Database;
using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context context;
        public CategoryRepository(Context context)
        {
            this.context = context;
        }
        public Category CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }



        public List<Category> GetCategories()
        {
            List<Category> categories = context.Categories.ToList();
            return categories;
        }

        public Category GetCategoryById(string id)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public void UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public Category GetCategoryByName(string name)
        {
            var category = context.Categories.FirstOrDefault(x => x.Name == name);
            return category;
        }
    }
}
