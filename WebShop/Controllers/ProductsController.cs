using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductServices _productService;

        public ProductsController(ProductServices productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _productService.GetProductsAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProduct(int id)
        {
            Product? product = await _productService.GetProductByIdAsync(id);
            return product is not null ? product : NotFound();
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (GetProduct(id) is not null)
            {
                await _productService.UpdateProductAsync(product);

            }
            return NotFound();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var productAdd = await _productService.AddProductAsync(product);
            return CreatedAtAction("GetProduct", new { id = productAdd.Id }, productAdd);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(product);

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _productService.GetProductByIdAsync(id) is null ? false : true;
        }
    }
}
