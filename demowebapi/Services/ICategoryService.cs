using demowebapi.Models;

namespace demowebapi.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int Id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int Id);
    }
}
