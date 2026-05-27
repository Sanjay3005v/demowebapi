using System.ComponentModel.DataAnnotations;

namespace demowebapi.Models
{
    public class Product
    {
        public Product(int id, string name, decimal price, int cid, string description, bool isAvailable)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            CatId = cid;
            Descriptions = description;
            this.isAvailable = isAvailable;
        }
        public Product()
        {
        }

        [Required] public int ProductId { get; set; }
        [Required] public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Descriptions { get; set; } = string.Empty;
        public bool isAvailable { get; set; }
        public int CatId { get; set; }
        public Category cart { get; set; }
    }
}