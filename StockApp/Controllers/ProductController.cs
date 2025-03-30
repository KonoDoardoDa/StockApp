using Microsoft.AspNetCore.Mvc;
using StockApp.Data;

namespace StockApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbContextStock _context;

        public ProductController(DbContextStock context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
