using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Shared.DTOs;
using Labb2_WebDev2._0.Shared.Interfaces;

namespace Labb2_WebDev2._0.Dataccess.Repositorys;

public class ProductRepository(HandmadeDbContext context) : IProductService<Product>
{
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return context.Products;
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<Product?> GetProductByEAN(long ean)
    {
        return await context.Products.FindAsync(ean);
    }

    public async Task AddProduct(Product newProduct)
    {
        await context.Products.AddAsync(newProduct);
        await context.SaveChangesAsync();
    }

    public async Task UpdateProductStatus(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product is null)
        {
            return;
        }
        product.Discontinued = true;
        await context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var removeProduct = await context.Products.FindAsync(id);
        if (removeProduct is null)
        {
            Console.WriteLine($"Product with id: {id} was not found");
            return;
        }
        context.Products.Remove(removeProduct);
        await context.SaveChangesAsync();
    }
}