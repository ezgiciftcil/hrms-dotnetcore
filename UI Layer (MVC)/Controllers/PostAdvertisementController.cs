using BusinessLayer.Services.Interfaces;
using EntityLayer.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class PostAdvertisementController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IJobAdvertisementService _jobAdvertisementService;
        public PostAdvertisementController(IJobAdvertisementService jobAdvertisementService, ICityService cityService)
        {
            _cityService = cityService;
            _jobAdvertisementService = jobAdvertisementService;
        }
        public IActionResult Index()
        {
            var citySelectList = new CitySelectList(_cityService);
            var cities = citySelectList.GetCities();
            ViewBag.cities = cities;
            ViewBag.employerId= Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            return View();
        }
        [HttpPost]
        public IActionResult Index(EmployerJobAdvertisement jobAdvertisement)
        {
            var newAdvertisement = new EmployerJobAdvertisementDTO
            {
                CityId = jobAdvertisement.CityId,
                EmployerId = jobAdvertisement.EmployerId,
                JobDescription = jobAdvertisement.JobDescription,
                JobTitle = jobAdvertisement.JobTitle,
                MaxSalary = jobAdvertisement.MaxSalary,
                MinSalary = jobAdvertisement.MinSalary
            };
            if (_jobAdvertisementService.AddJobAdvertisement(newAdvertisement).Success)
            {
                return RedirectToAction("Index", "PostedAdvertisements");
            }
            return RedirectToAction("Index", "PostAdvertisement");
        }
    }
}
