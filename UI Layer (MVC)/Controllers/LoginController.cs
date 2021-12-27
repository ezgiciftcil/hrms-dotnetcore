using Microsoft.AspNetCore.Mvc;

namespace UI_Layer__MVC_.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JobSeekerLogin()
        {
            return View();
        }
        
        public IActionResult EmployerLogin()
        {
            return View();
        }
    }
}
