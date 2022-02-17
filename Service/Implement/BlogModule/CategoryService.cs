using Data.DataAccess.Interface.BlogModule;
using Data.Model.BlogModule;
using Service.Interface.BlogModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement.BlogModule
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Category CreateCategory(Category category)
        {
            return categoryRepository.CreateCategory(category);
        }

        public List<Category> GetCategories()
        {
            return categoryRepository.GetCategories();
        }

        public Category GetCategoryById(string id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }

        public Category GetCategoryByName(string Name)
        {
            return categoryRepository.GetCategoryByName(Name);
        }
    }
}
