using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly WebShopDbContext _webShopDbContext;

        public CustomerServices(WebShopDbContext webShopDbContext)
        {
            _webShopDbContext = webShopDbContext;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _webShopDbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _webShopDbContext.Customers.FindAsync(id);
        }

        public async Task PutCustomerAsync(Customer customer)
        {
            _webShopDbContext.Update(customer);
            await _webShopDbContext.SaveChangesAsync();
        }

        public async Task<Customer> PostCustomerAsync(Customer customer)
        {
            _webShopDbContext.Customers.Add(customer);
            await _webShopDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _webShopDbContext.Customers.Remove(customer);
            await _webShopDbContext.SaveChangesAsync();
        }
    }
}
