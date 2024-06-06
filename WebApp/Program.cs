using Labb2_WebDev2._0.Shared.DTOs;
using Labb2_WebDev2._0.Shared.Interfaces;
using WebApp.Components;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("RestApi", client =>
{
    client.BaseAddress = new Uri(System.Environment.GetEnvironmentVariable("apiUrl") ?? "http://localhost:5231");
});

builder.Services.AddScoped<IProductService<ProductDTO>, ProductServices>();
builder.Services.AddScoped<IOrderService<OrderDTO>, OrderServices>();
builder.Services.AddScoped<ICustomerService<CustomerDTO>, CustomerServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
