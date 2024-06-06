using Labb2_WebDev2._0.Dataccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Labb2_WebDev2._0.Dataccess;

public class HandmadeDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public HandmadeDbContext(DbContextOptions<HandmadeDbContext> options) : base(options) { }
}