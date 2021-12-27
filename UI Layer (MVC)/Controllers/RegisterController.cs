using Microsoft.AspNetCore.Mvc;

namespace UI_Layer__MVC_.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JobSeekerRegister()
        {
            return View();
        }

        public IActionResult EmployerRegister()
        {
            return View();
        }
    }
}
