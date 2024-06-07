using Labb2_WebDev2._0.Shared.DTOs;
using Labb2_WebDev2._0.Shared.Interfaces;
using Newtonsoft.Json;

namespace WebApp.Services;

public class ProductServices : IProductService<ProductDTO>
{
    private readonly HttpClient _httpClient;

    public ProductServices(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("RestApi");
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        var response = await _httpClient.GetAsync("products/");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<ProductDTO>();
        }

        var result = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();
        return result ?? Enumerable.Empty<ProductDTO>();
    }

    public async Task<ProductDTO?> GetProductById(int id)
    {
        var response = await _httpClient.GetAsync($"products/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(result);
            return product;
        }
        return null;
    }

    public async Task<ProductDTO?> GetProductByEAN(long ean)
    {
        var response = await _httpClient.GetAsync($"products/search/{ean}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(result);
            return product;
        }
        return null;
    }

    public async Task AddProduct(ProductDTO newProduct)
    {
	    await _httpClient.PutAsJsonAsync($"/products", newProduct);

    }

    public async Task UpdateProductStatus(int id)
    {
	    await _httpClient.PatchAsJsonAsync($"/products/{id}",id);
    }

    public async Task DeleteProduct(int id)
    {
        var respons = await _httpClient.GetAsync($"products/{id}");
        if (!respons.IsSuccessStatusCode)
        {
            return;
        }
        var result = await respons.Content.ReadAsStringAsync();
        await _httpClient.DeleteAsync(result);
    }
}