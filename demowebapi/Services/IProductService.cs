using demowebapi.Models;

namespace demowebapi.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int Id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
    }
}