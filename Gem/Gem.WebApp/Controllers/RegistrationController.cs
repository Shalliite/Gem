using Microsoft.AspNetCore.Mvc;
using Gem.WebApp.Models;
using Gem.WebApp.Services;
using Gem.WebApp.Migrations;

namespace Gem.WebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private UserRepository _userRepository;
        public RegistrationController(ApplicationDbContext adbc)
        {
            _userRepository = new UserRepository(adbc);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegistrationModel registerDetails)
        {
            if (ModelState.IsValid)
            {
                MapUsers mapUsers = new MapUsers();
                User user = mapUsers.Map(registerDetails);
                if (_userRepository.IsRegistered(user))
                {
                    ViewBag.Message = $"{user.Email} is already registered!";
                    return View(registerDetails);
                }
                else
                {
                    _userRepository.Add(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(registerDetails);
            }
        }
    }
}
