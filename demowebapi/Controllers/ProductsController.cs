using demowebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demowebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
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

        private readonly List<Product> _products = new()
        {
            new Product
            {
                ProductId = 101,
                ProductName = "Laptop",
                ProductPrice = 90000,
                CatId = 1,
                isAvailable = true,
                Descrptions = "Laptop"
            },

            new Product
            {
                ProductId = 102,
                ProductName = "Smart Phone",
                ProductPrice = 9000,
                CatId = 1,
                isAvailable = true,
                Descrptions = "Phone"
            },

            new Product
            {
                ProductId = 103,
                ProductName = "Headphones",
                ProductPrice = 900,
                CatId = 2,
                isAvailable = true,
                Descrptions = "Headphone"
            },

            new Product
            {
                ProductId = 104,
                ProductName = "Desktop",
                ProductPrice = 80000,
                CatId = 1,
                isAvailable = true,
                Descrptions = "Desktop"
            },

            new Product
            {
                ProductId = 105,
                ProductName = "iPhone",
                ProductPrice = 95000,
                CatId = 1,
                isAvailable = true,
                Descrptions = "iPhone"
            }
        };

        [HttpGet]

        public string GetProduct()
        {
            return "GETNAME";
        }
        [HttpGet]
        public string Get()
        {
            return "Get";
        }
        [HttpGet("{pid}")]
        public ActionResult<Product> GetProductById(int pid)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == pid);

            if (product == null)
            {
                return NotFound(new
                {
                    Message = "Product Not Found"
                });
            }

            return Ok(product);
        }
    }

}