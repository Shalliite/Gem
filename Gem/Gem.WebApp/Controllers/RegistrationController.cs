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
        public IActionResult Register(RegistrationModel registerDetails)
        {
            if (ModelState.IsValid)
            {
                if (registerDetails.Password != registerDetails.ConfirmPassword)
                {
                    ViewBag.Message = "Passwords do not match. Please retype your password.";
                }
                else
                {
                    MapUsers mapUsers = new MapUsers();
                    User user = mapUsers.Map(registerDetails);
                    if (_userRepository.IsRegistered(user))
                    {
                        ViewBag.Message = $"{user.Email} is already registered!";
                    }

                    else
                    {
                        ViewBag.Message = "User registration is successful!";
                        _userRepository.Add(user);
                    }
                }
            }
            return View("Index");
        }
    }
}
