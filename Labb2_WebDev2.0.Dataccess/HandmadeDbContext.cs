﻿using Labb2_WebDev2._0.Dataccess.Entities;
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
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HandmadeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}