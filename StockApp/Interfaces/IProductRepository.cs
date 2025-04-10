using StockApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.Repositories
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize);
        Task<List<Product?>> SearchAsync(string? productId = null, int? providerId = null, string? description = null);
        Task AddProductAsync(Product product);
        // Task UpdateProductAsync(Product product);
        // Task DeleteProductAsync(string Productid);
    }
}
