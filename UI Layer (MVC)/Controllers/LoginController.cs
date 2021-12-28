using BusinessLayer.Auth.DTOs;
using BusinessLayer.Auth.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _registerService;
        public LoginController(IAuthService registerService)
        {
            _registerService = registerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JobSeekerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult JobSeekerLogin(UserLogin user)
        {
            var loginUser = new UserDTO
            {
                Email = user.Email,
                Password = user.Password
            };
            if ((_registerService.Login(loginUser).Success))
            {
                return RedirectToAction("Index", "Test");
            }

            return View();
        }

        [HttpPost]
        public IActionResult EmployerLogin(UserLogin user)
        {
            var loginUser = new UserDTO
            {
                Email = user.Email,
                Password = user.Password
            };
            if ((_registerService.Login(loginUser).Success))
            {
                return RedirectToAction("Index", "Test");
            }

            return View();
        }

        public IActionResult EmployerLogin()
        {
            return View();
        }
    }
}
