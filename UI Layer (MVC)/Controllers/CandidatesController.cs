using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer__MVC_.Controllers
{
    public class CandidatesController : Controller
    {
        public IActionResult Index(int JobAdvertisementId)
        {
            return View();
        }
    }
}
