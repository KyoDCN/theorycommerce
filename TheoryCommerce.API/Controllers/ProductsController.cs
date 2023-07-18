using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheoryCommerce.Core.Entities;
using TheoryCommerce.Core.Interfaces;
using TheoryCommerce.Core.Specifications;
using TheoryCommerce.Infrastructure.Data;

namespace TheoryCommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;

        public ProductsController(
            IGenericRepository<Product> product,
            IGenericRepository<ProductBrand> productBrand,
            IGenericRepository<ProductType> productType)
        {
            _product = product;
            _productBrand = productBrand;
            _productType = productType;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> ProductsAsync()
        {
            return Ok(await _product.GetAllAsync(new ProductsWithBrandsAndTypesSpec()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Product(int id)
        {
            return Ok(await _product.GetByIdAsync(id));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrand.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            return Ok(await _productType.GetAllAsync());
        }
    }
}
