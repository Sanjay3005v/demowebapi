namespace demowebapi.Dtos
{
    public class DeleteProductDTO
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int cartId { get; set; }
        public string Description { get; set; }
    }
}