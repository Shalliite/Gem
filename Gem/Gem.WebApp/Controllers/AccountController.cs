using Microsoft.AspNetCore.Mvc;
using Gem.WebApp.Models;
using Gem.WebApp.Services;
using Gem.WebApp.Migrations;

namespace Gem.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository _userRepository;
        public AccountController(ApplicationDbContext adbc)
        {
            _userRepository = new UserRepository(adbc);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginInfo)
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

        [HttpPost]
        public IActionResult Registration(RegistrationModel registerDetails)
        {
            if (ModelState.IsValid)
            {
                MapUsers mapUsers = new MapUsers();
                User user = mapUsers.Map(registerDetails);
                if (_userRepository.IsRegistered(user.Email))
                {
                    ViewBag.Message = $"{user.Email} is already registered!";
                }
                else
                {
                    _userRepository.Add(user);
                    return RedirectToAction("Login");
                }
            }
            return View(registerDetails);
        }
    }
}
