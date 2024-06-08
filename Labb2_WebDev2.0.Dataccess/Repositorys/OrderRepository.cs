using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Shared.DTOs;
using Labb2_WebDev2._0.Shared.Interfaces;

namespace Labb2_WebDev2._0.Dataccess.Repositorys;

public class OrderRepository(HandmadeDbContext context) : IOrderService<Order>
{
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return context.Orders;
    }

    public async Task<Order?> GetOrderById(int id)
    {
        var orderById = await context.Orders.FindAsync(id);
        if (orderById is null)
        {
            Console.WriteLine($"Order with id: {id} was not found");
            return null;
        }
        return orderById;
    }

    public async Task AddOrder(Order addOrder)
    {
        var customer = await context.Customers.FindAsync(addOrder.CustomerID);
        if (customer is null)
        {
            Console.WriteLine($"Order with id: {addOrder.CustomerID} was not found");
        }
        Order newOrder = new();
        newOrder.CustomerID = addOrder.CustomerID;
        newOrder.Products = addOrder.Products;
        newOrder.DateOfOrder = DateTime.Now;
        context.Orders.AddAsync(newOrder);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrderStatus(int id)
    {
        var updateOrder = await context.Orders.FindAsync(id);
        if (updateOrder is null)
        {
            Console.WriteLine($"Order with id: {id} was not found");
            return;
        }
        updateOrder.OrderShipped = true;
        await context.SaveChangesAsync();
    }

    public async Task RemoveOrder(int id)
    {
        var removeOrder = await context.Orders.FindAsync(id);
        if (removeOrder is null)
        {
            Console.WriteLine($"Order with id: {id} was not found");
            return;
        }
        context.Orders.Remove(removeOrder);
        await context.SaveChangesAsync();
    }
}