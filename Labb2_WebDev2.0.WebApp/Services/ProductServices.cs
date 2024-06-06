using Labb2_WebDev2.Shared.DTOs;
using Labb2_WebDev2.Shared.Interfaces;

namespace Labb2_WebDev2.WebApp.Services;

public class ProductServices : IProductService<ProductDTO>
{
    public Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO?> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO?> GetProductByEAN(int ean)
    {
        throw new NotImplementedException();
    }

    public Task AddProduct(ProductDTO newProduct)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductStatus(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}