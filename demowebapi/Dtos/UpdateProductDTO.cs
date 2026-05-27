namespace demowebapi.Dtos
{
    public class UpdateProductDTO
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public string Descrptions { get; set; } = string.Empty;
        public bool isAvailable { get; set; }
        public int CatId { get; set; }
    }
}