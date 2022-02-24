using Gem.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gem.WebApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(loginInfo);
            }
        }
    }
}
