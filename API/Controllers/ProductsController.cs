using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductType>>> Types()
        {
            var types = await _repo.GetTypesAsync();
            return Ok(types);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductBrand>>> Brands()
        {
            var brands = await _repo.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _repo.GetProductByIDAsync(id);
        }
    }
}