using demowebapi.Data;
using demowebapi.Dtos;
using demowebapi.Models;
using Microsoft.EntityFrameworkCore;

namespace demowebapi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDTO> AddCategory(CreateCategoryDTO category)
        {
            var newCategory = new Category
            {
                CatName = category.CatName,
            };
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            var cDTO = new CategoryDTO
            {
                CatId = newCategory.CatId,
                CatName = newCategory.CatName,
            };

            return cDTO;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return await _context.Categories
                .Select( c => new CategoryDTO
                {
                    CatId = c.CatId,
                    CatName = c.CatName,
                }).ToListAsync();
        }

        public async Task<CategoryDTO> GetCategoryById(int Id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CatId == Id);

            if (category == null)
            {
                return null;
            }
            var cDTO = new CategoryDTO
            {
                CatId = category.CatId,
                CatName = category.CatName
            };
            return cDTO;
        }

        public async Task<CategoryDTO> UpdateCategory(int id, UpdateCategoryDTO Updatecategory)
        {
            var category = await _context.Categories
                            .FirstOrDefaultAsync(c => c.CatId == id);

            if (category == null)
            {
                return null;
            }

            category.CatName = Updatecategory.CatName;
            await _context.SaveChangesAsync();

            return new CategoryDTO
            {
               CatId = category.CatId,
               CatName = category.CatName
            };
        }

        public async Task<DeleteCategoryDTO> DeleteCategory(int Id)
        {
            var category = await _context.Categories
                            .FirstOrDefaultAsync(c => c.CatId== Id);

            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            var delCategory = new DeleteCategoryDTO
            {
                CatName = category.CatName
            };
            return delCategory;
        }
    }
}
