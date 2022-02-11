using Data.Model.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();
        public Category CreateCategory(Category category);
        public Category GetCategoryById(string id);
        public void UpdateCategory(Category category);
        public Category GetCategoryByName(string name);
    }
}
