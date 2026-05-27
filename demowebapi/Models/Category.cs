namespace demowebapi.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public List<Product> products { get; set; }
    }
}