using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Repositories;

namespace StockApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbContextStock _context;
        private readonly IProductRepository _productRepository;

        public ProductController(DbContextStock context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var productsPaged = await _productRepository.GetProductsAsync(page, pageSize);
            return View(productsPaged);
        }
    }
}
