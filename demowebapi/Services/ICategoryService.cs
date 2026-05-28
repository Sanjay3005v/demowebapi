using demowebapi.Models;
using demowebapi.Dtos;

namespace demowebapi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int Id);
        Task<CategoryDTO> AddCategory(CreateCategoryDTO category);
        Task<CategoryDTO> UpdateCategory(int id, UpdateCategoryDTO category);
        Task<DeleteCategoryDTO> DeleteCategory(int Id);
    }
}
