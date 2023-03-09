using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecommerce.API.Dtos;
using ecommerce.Core.Entities;
using ecommerce.Core.Interfaces;
using ecommerce.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericService<Product> _productService;
        private readonly IGenericService<ProductBrand> _productBrandService;
        private readonly IGenericService<ProductType> _productTypeService;
        private readonly IMapper _mapper;

        public ProductsController(IGenericService<Product> productService, IGenericService<ProductBrand> productBrandService, 
            IGenericService<ProductType> productTypeService, IMapper mapper){
            _productService = productService;
            _productBrandService = productBrandService;
            _productTypeService = productTypeService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productService.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productService.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() 
        {
            return Ok(await _productBrandService.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() 
        {
            return Ok(await _productTypeService.ListAllAsync());
        }
    }
}