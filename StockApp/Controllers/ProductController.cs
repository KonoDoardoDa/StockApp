using Microsoft.AspNetCore.Mvc;
using StockApp.Data;
using StockApp.Interfaces;
using StockApp.Services;

namespace StockApp.Controllers
{
    public class ProductController(IProductService _productService) : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var productsPaged = await _productService.GetPagedAsync(page, pageSize);
            return View(productsPaged);
        }

        public async Task<IActionResult> Search(string? productId, int? providerId, string? description)
        {
            var results = await _productService.SearchAsync(productId, providerId, description);
            return View(results);
        }
    }
}
