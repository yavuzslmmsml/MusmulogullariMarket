using Microsoft.AspNetCore.Mvc;

namespace MusmulogullariMarket.AdminUI.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}