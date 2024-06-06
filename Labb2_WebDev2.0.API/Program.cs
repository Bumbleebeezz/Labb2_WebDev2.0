using Labb2_WebDev2._0.API.Extensions;
using Labb2_WebDev2._0.Dataccess;
using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Dataccess.Repositorys;
using Labb2_WebDev2._0.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("HandmadeDb");
builder.Services.AddDbContext<HandmadeDbContext>(
    options =>
        options.UseSqlServer(connectionString)
);

builder.Services.AddHttpClient("RestApi", client =>
{
    client.BaseAddress = new Uri(System.Environment.GetEnvironmentVariable("apiUrl") ?? "http://localhost:5231");
});

builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "API is running!");
app.MapOrderEndpoints();
app.MapProductEndpoints();
app.MapCustomerEndpoints();

app.Run();
