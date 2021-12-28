using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer__MVC_.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SessionId = HttpContext.Session.GetInt32(SessionInfo.SessionUserId);
            return View();
        }
    }
}
