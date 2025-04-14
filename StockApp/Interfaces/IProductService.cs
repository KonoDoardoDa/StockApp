using StockApp.Models;

namespace StockApp.Interfaces;

public interface IProductService
{
    Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize);
    Task<List<Product>> SearchAsync(string? productId = null, int? providerId = null, string? description = null);
    Task AddProductAsync(Product product);
    // Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}