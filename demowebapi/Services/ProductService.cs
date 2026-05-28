using demowebapi.Data;
using demowebapi.Dtos;
using demowebapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace demowebapi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDTO> AddProduct(CreateProductDTO product)
        {
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                CatId = product.CatId,
                Descriptions = product.Descriptions,
                ProductPrice = product.ProductPrice,
                isAvailable = product.isAvailable
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            var pDTO = new ProductDTO
            {
                ProductId = newProduct.ProductId,
                ProductName = newProduct.ProductName,
                CatId = newProduct.CatId,
                Descrptions = newProduct.Descriptions,
                ProductPrice = newProduct.ProductPrice,
                isAvailable = newProduct.isAvailable,
            };

            return pDTO;
        }

        public async Task<IEnumerable<ProductDTO>> SearchProductByprice(decimal price)
        {
            var products = await _context.Products
                    .Where(p => p.ProductPrice == price)
                    .Select(p => new ProductDTO
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CatId = p.CatId,
                        Descrptions = p.Descriptions,
                        ProductPrice = p.ProductPrice,
                        isAvailable = p.isAvailable
                    }).ToListAsync();

            return products;

        }
        public async Task<IEnumerable<ProductDTO>> GetProdPriceAvail(decimal price, bool Avail)
        {
            var products = await _context.Products
                    .Where(p => p.ProductPrice == price && p.isAvailable == Avail)
                    .Select(p => new ProductDTO
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CatId = p.CatId,
                        Descrptions = p.Descriptions,
                        ProductPrice = p.ProductPrice,
                        isAvailable = p.isAvailable
                    }).ToListAsync();

            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProdNamePriceAvail(string name, decimal price, bool Avail)
        {
            var products = await _context.Products
                    .Where(p => p.ProductName == name && p.ProductPrice == price && p.isAvailable == Avail)
                    .Select(p => new ProductDTO
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CatId = p.CatId,
                        Descrptions = p.Descriptions,
                        ProductPrice = p.ProductPrice,
                        isAvailable = p.isAvailable
                    }).ToListAsync();

            return products;
        }

        public async Task<DeleteProductDTO> DeleteProduct(int Id)
        {
            var product = await _context.Products
                            .FirstOrDefaultAsync(p => p.ProductId == Id);

            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            var delProduct = new DeleteProductDTO
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                cartId = product.CatId,
                Description = product.Descriptions
            };
            return delProduct;
        }

        public async Task<ProductDTO> GetProductById(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == Id);

            if (product == null)
            {
                return null;
            }
            var pDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CatId = product.CatId,
                Descrptions = product.Descriptions,
                ProductPrice = product.ProductPrice,
                isAvailable = product.isAvailable,
            };
            return pDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return await _context.Products
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CatId = p.CatId,
                    Descrptions = p.Descriptions,
                    ProductPrice = p.ProductPrice,
                    isAvailable = p.isAvailable
                }).ToListAsync();
        }

        public async Task<ProductDTO> UpdateProduct(int id, UpdateProductDTO updateProduct)
        {
            var product = await _context.Products
                            .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return null;

            product.ProductName = updateProduct.ProductName;
            product.CatId = updateProduct.CatId;
            product.Descriptions = updateProduct.Descriptions;
            product.ProductPrice = updateProduct.ProductPrice;
            product.isAvailable = updateProduct.isAvailable;

            await _context.SaveChangesAsync();

            return new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CatId = product.CatId,
                Descrptions = product.Descriptions,
                ProductPrice = product.ProductPrice,
                isAvailable = product.isAvailable
            };
        }
    }
}
