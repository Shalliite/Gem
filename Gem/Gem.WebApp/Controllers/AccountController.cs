using Microsoft.AspNetCore.Mvc;
using Gem.WebApp.Models;
using Gem.WebApp.Services;
using Gem.WebApp.Migrations;

namespace Gem.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository _userRepository;
        private ApplicationDbContext _adbc;
        private string _email;
        public AccountController(ApplicationDbContext adbc)
        {
            _adbc = adbc;
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
        public IActionResult ConfirmRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
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
                if (_userRepository.IsRegistered(user.Email) && _userRepository.IsPasswordCorrect(user.Email, user.Password))
                {
                    //TODO: login and prompt to email confirmation if not confirmed.
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid e-mail and password combination");
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
                user.Verified = false;
                Verification verification = new Verification(_adbc);
                if (_userRepository.IsRegistered(user.Email))
                {
                    ViewBag.Message = $"{user.Email} is already registered!";
                }
                else
                {
                    _userRepository.Add(user);
                    verification.SendCode(registerDetails.Email, "Account creation confirmation", "This is your code for registration confirmation:");
                    return RedirectToAction("Login");
                }
            }
            return View(registerDetails);
        }

        [HttpPost]
        public IActionResult ConfirmRegistration(RegistrationConfirmationModel rcm)
        {
            if (ModelState.IsValid)
            {
                Verification verification = new Verification(_adbc);
                if (verification.CheckCode(_email, rcm.VerificationCode))
                {
                    //TODO: return to chat page after successful confirmation
                    return View();
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid verification code!");
                }
            }
            return View(rcm);
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordModel fpm)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.IsRegistered(fpm.Email))
                {
                    Verification verification = new Verification(_adbc);
                    _email = fpm.Email;
                    verification.SendCode(fpm.Email, "Password reset code", "Hello, this is your password reset code:");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Cannot find user registered with {fpm.Email}");
                    return View(fpm);
                }
            }
            return View(fpm);
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordModel rpm)
        {
            if (ModelState.IsValid)
            {
                Verification verification = new Verification(_adbc);
                if (verification.CheckCode(_email, rpm.VerificationCode))
                {
                    _userRepository.ChangePassword(_email, rpm.Password);
                    _email = null;
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid verification code!");
                }
            }
            return View(rpm);
        }
    }
}