﻿using StockApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockApp.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(int page, int pageSize);
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
