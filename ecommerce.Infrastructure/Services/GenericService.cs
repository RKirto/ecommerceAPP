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
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericService(StoreContext context){
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}