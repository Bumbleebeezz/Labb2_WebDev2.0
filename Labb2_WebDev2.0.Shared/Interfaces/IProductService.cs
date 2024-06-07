using Labb2_WebDev2._0.Shared.DTOs;

namespace Labb2_WebDev2._0.Shared.Interfaces;

public interface IProductService<T> where T : class
{
    Task<IEnumerable<T>> GetAllProducts();
    Task<T?> GetProductById(int id);
    Task<T?> GetProductByEAN(int ean);
    Task AddProduct(T newProduct);
    Task UpdateProductStatus(int id);
    Task DeleteProduct(int id);
}