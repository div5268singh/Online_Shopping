using Microsoft.AspNetCore.Mvc;

namespace Online_Shopping_Web.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
