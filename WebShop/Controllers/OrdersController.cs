using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderServices _orderService;

        public OrdersController(OrderServices orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _orderService.GetOrdersAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order?>> GetOrder(int id)
        {
            Order? order = await _orderService.GetOrderByIdAsync(id);
            return order is not null ? order : NotFound();
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (GetOrder(id) is not null)
            {
                await _orderService.UpdateOrderAsync(order);
            }
            return NotFound();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            var orderAdd = await _orderService.AddOrderAsync(order);
            return CreatedAtAction("GetOrder", new { id = orderAdd.Id }, orderAdd);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrderAsync(order);

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _orderService.GetOrderByIdAsync(id) is null ? false : true;
        }
    }
}
