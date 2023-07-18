using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheoryCommerce.Core.Entities;
using TheoryCommerce.Infrastructure.Data;

namespace TheoryCommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> ProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Product(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(product);
        }
    }
}
