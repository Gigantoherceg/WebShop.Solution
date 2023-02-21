namespace Services.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new();
        public Customer Customer { get; set; }
    }
}
