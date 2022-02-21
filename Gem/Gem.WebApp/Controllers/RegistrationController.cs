using Microsoft.AspNetCore.Mvc;
using Gem.WebApp.Models;

namespace Gem.WebApp.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel registerDetails)
        {
            return View("Index");
        }
    }
}
