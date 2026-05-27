using demowebapi.Models;

namespace demowebapi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categories = new List<Category>
        {
            new Category
            {
                CatId = 1,
                CatName = "Electronics"
            },

            new Category
            {
                CatId = 2,
                CatName = "Accessories"
            }
        };

        public void AddCategory(Category category)
        {
            category.CatId = _categories.Max(c => c.CatId) + 1;
            _categories.Add(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int Id)
        {
            return _categories.FirstOrDefault(c => c.CatId == Id);
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.CatId == category.CatId);
            if (existingCategory != null)
            {
                existingCategory.CatName = category.CatName;
            }
        }

        public void DeleteCategory(int Id)
        {
            var category = _categories.FirstOrDefault(c => c.CatId == Id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
