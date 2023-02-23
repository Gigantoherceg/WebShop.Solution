﻿using Services.Models;

namespace Services
{
    public interface ICartServices
    {
        Task<Cart> AddCartAsync(CartView cart);
        Task DeleteCartAsync(Cart cart);
        Task<Cart?> GetCartByIdAsync(int id);
        Task<List<Cart>> GetCartsAsync();
        Task UpdateCartAsync(Cart cart);
    }
}