using demowebapi.Models;
using demowebapi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using demowebapi.Services;

namespace demowebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public string GetCategory()
        {
            return "GETCATEGORYNAME";
        }

        [HttpGet]
        public string Get()
        {
            return "Get";
        }
        [HttpGet("{catId}")]
        public async Task<ActionResult<Category>> GetCategoryById(int catId)
        {
            var category = await _categoryService.GetCategoryById(catId);
            if (category == null)
            {
                return NotFound(new
                {
                    Message = "Category Not Found"
                });
            }
            return Ok(new
            {
                Message = "Category fetched successfully.",
                Category = category
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO catDTO)
        {

            var cDTO = await _categoryService.AddCategory(catDTO);
            return Ok(new
            {
                Message = "Category created successfully.",
                Category = cDTO
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateCategoryDTO categoryDTO)
        {
            var category = await _categoryService.UpdateCategory(id,categoryDTO);

            if(category == null)
            {
                return NotFound(new
                {
                    Message = $"Category with ID {id} not found."
                });
            }

            return Ok(new
            {
                Message = "Category updated successfully.",
                Category = category
            });
        }

        [HttpDelete("{cid}")]
        public async Task<IActionResult> Delete(int cid)
        {
            var delCategory = await _categoryService.DeleteCategory(cid);

            if(delCategory == null)
            {
                return NotFound(new
                {
                    Message = $"Category with ID {cid} not found."
                });
            }

            return Ok(new
            {
                Message = "Category deleted seuucessfully.",
                Category = delCategory
            });
        }
    }
}
