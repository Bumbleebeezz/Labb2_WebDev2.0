using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Dataccess.Repositorys;

namespace Labb2_WebDev2._0.API.Extensions;

public static class OrderEndpointExtensions
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async (OrderRepository repo) =>
        {
            return await repo.GetAllOrders();
        });
        app.MapGet("/orders/{id}", async (OrderRepository repo, int id) =>
        {
            var order = await repo.GetOrderById(id);
            if (order is null)
            {
                return Results.NotFound($"Order with ID {id} was not found");
            }

            return Results.Ok(order);
        });
        app.MapPost("/orders", async (OrderRepository repo, Order newOrder) =>
        {
            await repo.AddOrder(newOrder);
        });
        app.MapPatch("/orders", async (OrderRepository repo,int id) =>
        {
            var excistingOrder = await repo.GetOrderById(id);
            if (excistingOrder is null)
            {
                return Results.BadRequest($"Order with id {id} was not found");
            }

            await repo.UpdateOrderStatus(id);
            return Results.Ok("Order status has been updated");
        });
        app.MapGet("/orders", async (OrderRepository repo, int id) =>
        {
            await repo.RemoveOrder(id);
        });

        return app;
    }
}