using Labb2_WebDev2._0.Dataccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Labb2_WebDev2._0.Dataccess;

public class HandmadeDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public HandmadeDbContext() { }
    public HandmadeDbContext(DbContextOptions<HandmadeDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=MARIACONFIG;Integrated Security=True;Initial Catalog=HandmadeDb;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}