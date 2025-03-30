using Microsoft.AspNetCore.Mvc;

namespace StockApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var message = "Bem-vindo ao StockApp!";
            return View("Index", message); // Passando a variável para a view
        }
    }
}
