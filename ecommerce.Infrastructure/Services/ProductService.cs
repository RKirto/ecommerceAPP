using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Core.Entities;
using ecommerce.Core.Interfaces;
using ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreContext _context;
        public ProductService(StoreContext context){
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}