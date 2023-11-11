using Microsoft.AspNetCore.Mvc;

namespace Online_Shopping_Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
