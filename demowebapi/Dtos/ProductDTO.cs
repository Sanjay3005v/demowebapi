namespace demowebapi.Dtos
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public string Descrptions { get; set; } = string.Empty;
        public bool isAvailable { get; set; }
        public int CatId { get; set; }

    }
}