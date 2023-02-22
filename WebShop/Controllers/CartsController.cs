using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartServices _cartServices;

        public CartsController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _cartServices.GetCartsAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart?>> GetCart(int id)
        {
            Cart? cart = await _cartServices.GetCartByIdAsync(id);
            return cart is not null ? cart : NotFound();
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (await _cartServices.GetCartByIdAsync(id) is not null)
            {
                await _cartServices.UpdateCartAsync(cart);
                return Ok(cart);
            }
            return NotFound();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostProduct(Cart cart)
        {
            var cartAdd = await _cartServices.AddCartAsync(cart);
            return CreatedAtAction("GetCart", new { id = cartAdd.Id }, cartAdd);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecart(int id)
        {
            var cart = await _cartServices.GetCartByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            await _cartServices.DeleteCartAsync(cart);
            return NoContent();
        }

        private bool CartExists(int id)
        {
            return _cartServices.GetCartByIdAsync(id) is null ? false : true;
        }
    }
}
