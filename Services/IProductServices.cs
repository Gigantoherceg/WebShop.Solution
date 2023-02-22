using Services.Models;

namespace Services
{
    public interface IProductServices
    {
        Task<Product> AddProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task UpdateProductAsync(Product product);
    }
}