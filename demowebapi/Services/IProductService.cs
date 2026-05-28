using demowebapi.Dtos;
using demowebapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace demowebapi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int Id);
        Task<ProductDTO> AddProduct(CreateProductDTO product);
        Task<IEnumerable<ProductDTO>> SearchProductByprice(decimal price);
        Task<IEnumerable<ProductDTO>> GetProdPriceAvail(decimal price, bool avail);
        Task<ProductDTO> UpdateProduct(int id, UpdateProductDTO product);
        Task<IEnumerable<ProductDTO>> GetProdNamePriceAvail(string pName, decimal pPrice, bool pAvail);
        Task<DeleteProductDTO> DeleteProduct(int Id);
    }
}