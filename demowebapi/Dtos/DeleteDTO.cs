namespace demowebapi.Dtos
{
    public class DeleteDTO
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int cartId { get; set; }
        public string Description { get; set; }
    }
}