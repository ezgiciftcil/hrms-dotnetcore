using BusinessLayer.Auth.DTOs;
using BusinessLayer.Auth.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService registerService)
        {
            _authService = registerService;
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
            if ((_authService.Login(loginUser).Success))
            {
                var userId = _authService.GetUserId(user.Email);
                HttpContext.Session.SetInt32(SessionInfo.SessionUserId, userId);
                return RedirectToAction("JobSeekerHome", "Home");
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
            if ((_authService.Login(loginUser).Success))
            {
                var userId = _authService.GetUserId(user.Email);
                HttpContext.Session.SetInt32(SessionInfo.SessionUserId, userId);
                return RedirectToAction("EmployerHome", "Home");
            }

            return View();
        }

        public IActionResult EmployerLogin()
        {
            return View();
        }
    }
}
