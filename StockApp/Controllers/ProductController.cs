using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Repositories;

namespace StockApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbContextStock _context;
        private readonly IProductRepository _productRepository;

        public ProductController(DbContextStock context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var productsPaged = await _productRepository.GetPagedAsync(page, pageSize);
            return View(productsPaged);
        }
    }
}
