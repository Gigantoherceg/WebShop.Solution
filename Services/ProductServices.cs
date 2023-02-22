using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services
{
    public class ProductServices : IProductServices
    {
        private readonly WebShopDbContext _context;

        public ProductServices(WebShopDbContext context)
        {
            _context = context;
        }
        //GET
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        //GET id alapján
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null)
            {
                _context.Entry(product).State = EntityState.Detached;
            }
            return product;
        }

        //PUT => Update id alapján
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        //POST => ADD
        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        //DELETE
        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}