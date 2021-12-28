using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer__MVC_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult JobSeekerHome()
        {
            return View();
        }

        public IActionResult EmployerHome()
        {
            return View();
        }
    }
}
