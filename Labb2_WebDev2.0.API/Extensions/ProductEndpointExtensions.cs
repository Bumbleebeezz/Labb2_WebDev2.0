using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Dataccess.Repositorys;

namespace Labb2_WebDev2._0.API.Extensions;

public static class ProductEndpointExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ProductRepository repo) =>
        {
            return await repo.GetAllProducts();
        });

        app.MapGet("/products/{id}", async (ProductRepository repo, int id) =>
         {
             var product = await repo.GetProductById(id);
             if (product is null)
             {
                 return Results.NotFound($"Product with ID {id} was not found");
             }

             return Results.Ok(product);
         });

        app.MapGet("/products/search/{ean}", async (ProductRepository repo, string ean) =>
        {
            var product = await repo.GetProductByEAN(ean);
            if (product is null)
            {
                return Results.NotFound($"Product with EAN {ean} was not found");
            }

            return Results.Ok(product);
        });

        app.MapPost("/products", async (ProductRepository repo, Product newProduct) =>
        {
            await repo.AddProduct(newProduct);
        });

        app.MapPatch("/products/{id}", async (ProductRepository repo, int id) =>
        {
            var excistingProduct = await repo.GetProductById(id);
            if (excistingProduct is null)
            {
                return Results.BadRequest($"Product with id {id} was not found");
            }

            await repo.UpdateProductStatus(id);
            return Results.Ok("Product has been updated");
        });

        app.MapDelete("/products/{id}", async (ProductRepository repo, int id) =>
        {
            var excistingProduct = await repo.GetProductById(id);
            if (excistingProduct is null)
            {
                return Results.BadRequest($"Product with id {id} was not found");
            }
            await repo.DeleteProduct(id);
            return Results.Ok("Product has been removed");
        });


        return app;
    }
}