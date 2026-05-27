using System.ComponentModel.DataAnnotations;

namespace demowebapi.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public string? ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
