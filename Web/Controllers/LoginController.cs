using Microsoft.AspNetCore.Mvc;

namespace Online_Shopping_Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult GetRoleList()
        {
            return View();
        }
    }
}
