using Microsoft.EntityFrameworkCore;
using StockApp.Data;
using StockApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
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

        public async Task<IEnumerable<Product>> GetAllProductAsync(int pageNumber, int pageSize)
        {
            return await _context.Products.OrderBy(p => p.ProductId).ToPagedList(pageNumber, pageSize);
        }
    }
}
