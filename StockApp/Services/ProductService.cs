using StockApp.Interfaces;
using StockApp.Models;
using StockApp.Repositories;

namespace StockApp.Services;

public class ProductService(IProductRepository _repository) : IProductService
{
    public async Task<PagedResult<Product>>GetPagedAsync(int page,int pageSize)
    {
        return await _repository.GetPagedAsync(page, pageSize);
    }

    public async Task<List<Product>> SearchAsync(string? productId = null, int? providerId = null, string? description = null)
    {
        return await _repository.SearchAsync(productId, providerId, description);
    }
    
}