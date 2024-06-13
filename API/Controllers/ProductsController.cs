using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {       
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo, 
            IGenericRepository<ProductType> productTypeRepo, 
            IGenericRepository<ProductBrand> productBrandRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
        {
            var spec = new ProductsWithTypesAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductToReturnDto>(product);
           
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandSpecification();
            var products = await _productRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products).ToList());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductType>>> Types()
        {
            var types = await _productTypeRepo.ListAllAsync();
            return Ok(types);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductBrand>>> Brands()
        {
            var brands = await _productBrandRepo.ListAllAsync();
            return Ok(brands);
        }
    }
}