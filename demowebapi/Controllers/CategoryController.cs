using demowebapi.Models;
using demowebapi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace demowebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
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
        public ActionResult<Category> GetCategoryById(int catId)
        {
            var category = _categories.FirstOrDefault(c => c.CatId == catId);
            if (category == null)
            {
                return NotFound(new
                {
                    Message = "Category Not Found"
                });
            }
            var catDTO = new CategoryDTO
            {
                CatId = category.CatId,
                CatName = category.CatName
            };

            return Ok(catDTO);
        }

        [HttpPost]
        public ActionResult<CreateCategoryDTO> Create(CreateCategoryDTO catDTO)
        {
            var category = new Category
            {
                CatId = _categories.Max(c => c.CatId) + 1,
                CatName = catDTO.CatName
            };
            _categories.Add(category);
            var cDTO = new CategoryDTO
            {
                CatId = category.CatId,
                CatName = category.CatName
            };
            return CreatedAtAction(nameof(GetCategoryById), new { catId = category.CatId }, cDTO);
        }

        [HttpPut]
        public ActionResult<UpdateCategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.CatId == categoryDTO.CatId);
            if (existingCategory != null) {
                existingCategory.CatName = categoryDTO.CatName;
                var uDTO = new UpdateCategoryDTO
                {
                    CatName = categoryDTO.CatName
                };
                return Ok(uDTO);
            }
            return NotFound();
        }

        [HttpDelete("{catId}")]
        public ActionResult<DeleteCategoryDTO> Delete(int pid)
        {
            var category = _categories.FirstOrDefault(c => c.CatId == pid);
            if (category == null)
            {
                return NotFound(new
                {
                    Message = "Category Not Found"
                });
            }
            _categories.Remove(category);
            var dDTO = new DeleteCategoryDTO
            {
                CatName = category.CatName
            };
            return Ok(dDTO);
        }
    }
}
