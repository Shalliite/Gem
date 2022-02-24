using Gem.WebApp.Migrations;
using Gem.WebApp.Models;
using Gem.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gem.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private UserRepository _userRepository;
        public LoginController(ApplicationDbContext adbc)
        {
            _userRepository = new UserRepository(adbc);
        }
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
                MapUsers mapUsers = new MapUsers();
                User user = mapUsers.Map(loginInfo);
                if (_userRepository.IsRegistered(user.Email))
                {
                    if (_userRepository.IsPasswordCorrect(user.Email, user.Password))
                    {
                        return RedirectToAction("Index", "Chat");
                    }
                    else
                    {
                        ViewBag.Message = "Password you entered is not correct";
                    }
                }
                else
                {
                    ViewBag.Message = "Cannot find any person registered with this email";
                }
            }
            return View(loginInfo);
        }
    }
}