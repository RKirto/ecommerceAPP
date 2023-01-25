using ecommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.API.DataContext;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) {}
    public DbSet<Product> Products { get; set; }
}