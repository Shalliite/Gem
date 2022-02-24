using Microsoft.AspNetCore.Mvc;

namespace Gem.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
