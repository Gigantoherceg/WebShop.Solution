using Microsoft.EntityFrameworkCore;

namespace Services.Models
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
