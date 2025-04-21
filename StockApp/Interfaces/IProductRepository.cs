using StockApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockApp.DTOs;

namespace StockApp.Repositories
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize);
        Task<List<Product?>> SearchAsync(string? productId = null, int? providerId = null, string? description = null);
        Task<Product> GetByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task<bool> EditProductAsync(EditProductDTO editDto);
        Task DeleteProductAsync(Product product);
    }
}
