using Services.Models;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> AddOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<List<Order>> GetOrdersAsync();
        Task UpdateOrderAsync(Order order);
    }
}