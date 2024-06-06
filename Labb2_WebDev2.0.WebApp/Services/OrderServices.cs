using Labb2_WebDev2.Shared.DTOs;
using Labb2_WebDev2.Shared.Interfaces;

namespace Labb2_WebDev2.WebApp.Services;

public class OrderServices : IOrderService<OrderDTO>
{
    public Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDTO?> GetOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddOrder(int customerID, List<int> productsID)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderStatus(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveOrder(int id)
    {
        throw new NotImplementedException();
    }
}