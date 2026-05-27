using demowebapi.Models;

namespace demowebapi.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> Products = new()
        {
            new Product
            {
                ProductId = 101,
                ProductName = "Laptop",
                ProductPrice = 90000,
                CatId = 1,
                isAvailable = true,
                Descriptions = "Laptop"
            },

            new Product
            {
                ProductId = 102,
                ProductName = "Smart Phone",
                ProductPrice = 9000,
                CatId = 1,
                isAvailable = true,
                Descriptions = "Phone"
            },

            new Product
            {
                ProductId = 103,
                ProductName = "Headphones",
                ProductPrice = 900,
                CatId = 2,
                isAvailable = true,
                Descriptions = "Headphone"
            },

            new Product
            {
                ProductId = 104,
                ProductName = "Desktop",
                ProductPrice = 80000,
                CatId = 1,
                isAvailable = true,
                Descriptions = "Desktop"
            },

            new Product
            {
                ProductId = 105,
                ProductName = "iPhone",
                ProductPrice = 95000,
                CatId = 1,
                isAvailable = true,
                Descriptions = "iPhone"
            }
        };

        public void AddProduct(Product product)
        {
            product.ProductId = Products.Max(p => p.ProductId + 1);
            Products.Add(product);
        }

        public void DeleteProduct(int Id)
        {
            var p = Products.FirstOrDefault(p => p.ProductId == Id);
            if (p != null)
            {
                Products.Remove(p);
            }
        }

        public Product GetProductById(int Id)
        {
            return Products.FirstOrDefault(p => p.ProductId == Id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductPrice = product.ProductPrice;
                existingProduct.CatId = product.CatId;
                existingProduct.Descriptions = product.Descriptions;
                existingProduct.isAvailable = product.isAvailable;
                return;
            }

        }
    }
}
