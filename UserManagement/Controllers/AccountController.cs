using Humanizer;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Domain.DTOs;
using UserManagement.Domain.Interfaces;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;


        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Login() => View();


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var dto = new LoginDto
            {
                UserName = model.UserName,
                Password = model.Password,
            };

            var user = await _userService.LoginAsync(dto);
            if (user != null)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError(string.Empty, "Invalid Username or Password");
            return View(model);
        }


        [HttpGet]
        public IActionResult Register() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var dto = new RegisterDto
            {
                UserName = model.UserName,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };


            var success = await _userService.RegisterAsync(dto);
            if (success)
                return RedirectToAction("Login");


            ModelState.AddModelError(string.Empty, "Registration failed.");
            return View(dto);
        }


        [HttpGet]
        public IActionResult ResetPassword() => View();


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = new ResetPasswordDto
            {
                Email = model.Email,
                NewPassword = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };

            var success = await _userService.ResetPasswordAsync(dto);
            if (success)
                ViewBag.Message = "Password reset successful.";
            else
                ModelState.AddModelError(string.Empty, "Password reset failed.");


            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
