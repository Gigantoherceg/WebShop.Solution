using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices
    {
        private readonly WebShopDbContext _webShopDbContext;

        public OrderServices(WebShopDbContext webShopDbContext)
        {
            _webShopDbContext = webShopDbContext;
        }
        //GET
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _webShopDbContext.Orders.ToListAsync();
        }

        //GET id alapján
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _webShopDbContext.Orders.FindAsync(id);
        }

        //PUT => Update id alapján
        public async Task UpdateOrderAsync(Order order)
        {
            _webShopDbContext.Entry(order).State = EntityState.Modified;

            await _webShopDbContext.SaveChangesAsync();
        }

        //POST => ADD
        public async Task<Order> AddOrderAsync(Order order)
        {
            _webShopDbContext.Orders.Add(order);
            await _webShopDbContext.SaveChangesAsync();

            return order;
        }

        //DELETE
        public async Task DeleteOrderAsync(Order order)
        {
            _webShopDbContext.Orders.Remove(order);
            await _webShopDbContext.SaveChangesAsync();
        }
    }
}