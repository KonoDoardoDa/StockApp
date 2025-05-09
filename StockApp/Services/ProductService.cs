using StockApp.DTOs;
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

    public async Task AddProductAsync(Product product)
    {
        await _repository.AddProductAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null)
            throw new ArgumentException($"Produto: {product.ProductId} não encontrado.");
        
        await _repository.DeleteProductAsync(product);
    }

    public async Task EditProductAsync(EditProductDTO editDto)
    {
        var succes = await _repository.EditProductAsync(editDto);

        if (!succes)
            throw new ArgumentException($"Produto com id: {editDto.ProductId} não encontrado.");
    }
}