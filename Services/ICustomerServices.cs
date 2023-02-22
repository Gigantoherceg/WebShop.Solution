using Services.Models;

namespace Services
{
    public interface ICustomerServices
    {
        Task DeleteCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> PostCustomerAsync(Customer customer);
        Task PutCustomerAsync(Customer customer);
    }
}