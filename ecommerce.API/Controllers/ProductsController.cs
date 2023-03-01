using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Core.Entities;
using ecommerce.Core.Interfaces;
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

        public ProductsController(IGenericService<Product> productService, IGenericService<ProductBrand> productBrandService, IGenericService<ProductType> productTypeService){
            _productService = productService;
            _productBrandService = productBrandService;
            _productTypeService = productTypeService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _productService.ListAllAsync());
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