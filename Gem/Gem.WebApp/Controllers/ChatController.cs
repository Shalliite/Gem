using Microsoft.AspNetCore.Mvc;

namespace Gem.WebApp.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
