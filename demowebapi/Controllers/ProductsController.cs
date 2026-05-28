using demowebapi.Dtos;
using demowebapi.Models;
using demowebapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace demowebapi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



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
        public async Task<ActionResult<Product>> GetProductById(int pid)
        {
            var product = await _productService.GetProductById(pid);

            if (product == null)
            {
                return NotFound(new
                {
                    Message = $"Product with ID {pid} not found."
                });
            }

            return Ok(new
            {
                Message = "Product fetched successfully.",
                Product = product
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO product)
        {
            var pDTO = await _productService.AddProduct(product);

            return Ok(new
            {
                Message = "Product created successfully.",
                Product = pDTO
            });
        }

        [HttpGet("Search")]
        public async Task<ActionResult> SearchProduct(decimal price)
        {
            var filterProd = await _productService.SearchProductByprice(price);
            if (!filterProd.Any())
            {
                return NotFound(new
                {
                    Message = $"No products found with price {price}"
                });
            }
            return Ok(new
            {
                Message = "Products fetched successfully.",
                Products = filterProd
            });
        }

        [HttpGet("Price/{price}/Avail/{Avail}")]
        public async Task<IActionResult> GetProdPriceAvail(decimal price, bool Avail)
        {
            var filterProd = await _productService.GetProdPriceAvail(price, Avail);
            if (!filterProd.Any())
            {
                return NotFound(new
                {
                    Message = $"No products found with price {price} and Availability"
                });
            }
            return Ok(new
            {
                Message = "Products fetched successfully.",
                Products = filterProd
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetProducts();

            if (!products.Any())
            {
                return NotFound(new
                {
                    Message = "No products found."
                });
            }

            return Ok(new
            {
                Message = "Products fetched successfully.",
                Products = products
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateProductDTO updateProduct)
        {
            var product = await _productService.UpdateProduct(id, updateProduct);

            if (product == null)
            {
                return NotFound(new
                {
                    Message = $"Product with ID {id} not found."
                });
            }

            return Ok(new
            {
                Message = "Product updated successfully.",
                Product = product
            });
        }

        [HttpDelete("{pid}")]
        public async Task<IActionResult> Delete(int pid)
        {
            var delProduct = await _productService.DeleteProduct(pid);

            if (delProduct == null)
            {
                return NotFound(new
                {
                    Message = $"Product with ID {pid} not found."
                });
            }

            return Ok(new
            {
                Message = "Product deleted successfully.",
                Product = delProduct
            });
        }



        [HttpGet("Name/{name}/Price/{price}/Avail/{Avail}")]
        public async Task<IActionResult> GetProdNamePriceAvail(string name, decimal price, bool Avail)
        {
            var filterProd = await _productService.GetProdNamePriceAvail(name, price, Avail);
            if (!filterProd.Any())
            {
                return NotFound(new
                {
                    Message = $"No products found with name {name}, price {price} and Availability"
                });
            }
            return Ok(new
            {
                Message = "Products fetched successfully.",
                Products = filterProd
            });
        }
    }

}

