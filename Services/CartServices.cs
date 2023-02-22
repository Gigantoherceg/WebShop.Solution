using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CartServices : ICartServices
    {
        private readonly WebShopDbContext _webShopDbContext;

        public CartServices(WebShopDbContext webShopDbContext)
        {
            _webShopDbContext = webShopDbContext;
        }

        public async Task<List<Cart>> GetCartsAsync()
        {
            return await _webShopDbContext.Carts.ToListAsync();
        }

        //GET id alapján
        public async Task<Cart?> GetCartByIdAsync(int id)
        {
            return await _webShopDbContext.Carts.FindAsync(id);
        }

        //PUT => Update id alapján
        public async Task UpdateCartAsync(Cart cart)
        {
            _webShopDbContext.Carts.Update(cart);
            await _webShopDbContext.SaveChangesAsync();
        }

        //POST => ADD
        public async Task<Cart> AddCartAsync(Cart cart)
        {
            _webShopDbContext.Carts.Add(cart);
            await _webShopDbContext.SaveChangesAsync();

            return cart;
        }

        //DELETE
        public async Task DeleteCartAsync(Cart cart)
        {
            _webShopDbContext.Carts.Remove(cart);
            await _webShopDbContext.SaveChangesAsync();
        }
    }
}