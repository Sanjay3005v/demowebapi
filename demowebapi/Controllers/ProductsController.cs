using demowebapi.Dtos;
using demowebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var pDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CatId = product.CatId,
                Descrptions = product.Descrptions,
                ProductPrice = product.ProductPrice,
                isAvailable = product.isAvailable
            };

            return Ok(pDTO);
        }
        [HttpPost]
        public ActionResult<ProductDTO> Create(CreateProductDTO product)
        {
            var newProduct = new Product
            {
                ProductId = _products.Max(p => p.ProductId + 1),
                ProductName = product.ProductName,
                CatId = product.CatId,
                Descrptions = product.Descrptions,
                ProductPrice = product.ProductPrice,
                isAvailable = product.isAvailable
            };
            _products.Add(newProduct);
            var pDTO = new ProductDTO
            {
                ProductId = newProduct.ProductId,
                ProductName = newProduct.ProductName,
                CatId = newProduct.CatId,
                Descrptions = newProduct.Descrptions,
                ProductPrice = newProduct.ProductPrice,
                isAvailable = newProduct.isAvailable
            };

            return CreatedAtAction(nameof(GetProductById), new { pid = pDTO.ProductId }, pDTO);
        }

        [HttpPut]
        public ActionResult<UpdateProductDTO> Update(ProductDTO product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.CatId = product.CatId;
                existingProduct.ProductPrice = product.ProductPrice;
                existingProduct.Descrptions = product.Descrptions;
                existingProduct.isAvailable = product.isAvailable;

                var uDTO = new UpdateProductDTO
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    Descrptions = product.Descrptions,
                    CatId = product.CatId,
                    isAvailable = product.isAvailable
                };
                return Ok(uDTO);
            }
            return NotFound();
        }

        [HttpDelete("{pid}")]
        public ActionResult<DeleteDTO> Delete(int pid)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == pid);
            if (product == null)
            {
                return NotFound("ID not found ");
            }
            _products.Remove(product);
            var DelDTO = new DeleteDTO
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                cartId = product.CatId,
                Description = product.Descrptions
            };
            return Ok(DelDTO);
        }
    }

}

