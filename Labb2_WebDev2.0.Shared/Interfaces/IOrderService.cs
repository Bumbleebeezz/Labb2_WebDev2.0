using Labb2_WebDev2._0.Shared.DTOs;

namespace Labb2_WebDev2._0.Shared.Interfaces;

public interface IOrderService<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrders();
    Task<T?> GetOrderById(int id);
    Task AddOrder(T newOrder);
    Task UpdateOrderStatus(int id);
    Task RemoveOrder(int id);
}