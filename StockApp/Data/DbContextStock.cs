using Microsoft.EntityFrameworkCore;
using StockApp.Models;

namespace StockApp.Data
{
    public class DbContextStock : DbContext
    {
        public DbContextStock(DbContextOptions<DbContextStock> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
