using Labb2_WebDev2._0.Shared.DTOs;
using Labb2_WebDev2._0.Shared.Interfaces;
using Newtonsoft.Json;

namespace WebApp.Services;

public class OrderServices : IOrderService<OrderDTO>
{
    private readonly HttpClient _httpClient;

    public OrderServices(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("RestApi");
    }

    public async Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        var respons = await _httpClient.GetAsync("orders/");
        if (!respons.IsSuccessStatusCode)
        {
            return Enumerable.Empty<OrderDTO>();
        }

        var result = await respons.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
        return result;
    }

    public async Task<OrderDTO?> GetOrderById(int id)
    {
        var respons = await _httpClient.GetAsync($"orders/{id}");
        if (!respons.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await respons.Content.ReadAsStringAsync();
        var order = JsonConvert.DeserializeObject<OrderDTO>(result);
        return order;
    }

    public async Task AddOrder(int customerID, List<int> productsID)
    {
        throw new NotImplementedException();

        //var respons = await _httpClient.PostAsJsonAsync($"orders/", neworder);
        //if (!respons.IsSuccessStatusCode)
        //{
        //    return;
        //}
        //return neworder;
    }

    public async Task UpdateOrderStatus(int id)
    {
        throw new NotImplementedException();

        //var respons = await _httpClient.GetAsync($"api/orders/{id}");
        //if (!respons.IsSuccessStatusCode)
        //{
        //    return;
        //}
        //var result = await respons.Content.ReadAsStringAsync();
    }

    public async Task RemoveOrder(int id)
    {
        var respons = await _httpClient.GetAsync($"api/orders/{id}");
        if (!respons.IsSuccessStatusCode)
        {
            return;
        }
        var result = await respons.Content.ReadAsStringAsync();
        _httpClient.DeleteAsync(result);
    }
}