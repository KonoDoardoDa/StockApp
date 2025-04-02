using Microsoft.EntityFrameworkCore;
using StockApp.Data;
using StockApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace StockApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextStock _context;

        public ProductRepository(DbContextStock context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int page, int pageSize)
        {
            var totalItems = await _context.Products.CountAsync();
            var items =  await _context.Products
                                        .OrderBy(p => p.Id)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return new PagedProducts<Product>
            {
                Items = items,
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page
            }
        }
    }
}
