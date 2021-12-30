using BusinessLayer.Services.Interfaces;
using EntityLayer.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class PostedAdvertisements : Controller
    {
        private readonly IJobAdvertisementService _jobAdvertisementService;
        private readonly ICityService _cityService;
        public PostedAdvertisements(IJobAdvertisementService jobAdvertisementService, ICityService cityService)
        {
            _jobAdvertisementService = jobAdvertisementService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var jobAds = _jobAdvertisementService.GetEmployerAllJobAdvertisements(userId).Data;
            var employerAdList = new List<EmployerJobAdvertisement>();
            foreach (var ad in jobAds)
            {
                if (ad.IsActive == true)
                {
                    var employerAd = new EmployerJobAdvertisement();
                    employerAd.JobAdvertisementId = ad.JobAdvertisementId;
                    employerAd.JobDescription = ad.JobDescription;
                    employerAd.JobTitle = ad.JobTitle;
                    employerAd.MaxSalary = ad.MaxSalary;
                    employerAd.MinSalary = ad.MinSalary;
                    employerAd.PublishDate = ad.PublishDate;
                    employerAd.CityId = ad.CityId;
                    employerAd.CityName = ad.CityName;
                    employerAd.EmployerId = ad.EmployerId;
                    employerAdList.Add(employerAd);
                }
            }
            return View(employerAdList);
        }

        public IActionResult CloseAd(int JobAdvertisementId)
        {
            if (_jobAdvertisementService.DeactiveJobAdvertisement(JobAdvertisementId).Success)
            {
                return RedirectToAction("Index", "PostedAdvertisements");
            }
            return RedirectToAction("Index", "PostedAdvertisements");
        }

        public IActionResult GetDeactiveAds()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var jobAds = _jobAdvertisementService.GetEmployerAllJobAdvertisements(userId).Data;
            var employerAdList = new List<EmployerJobAdvertisement>();
            foreach (var ad in jobAds)
            {
                if (ad.IsActive == false)
                {
                    var employerAd = new EmployerJobAdvertisement();
                    employerAd.JobAdvertisementId = ad.JobAdvertisementId;
                    employerAd.JobDescription = ad.JobDescription;
                    employerAd.JobTitle = ad.JobTitle;
                    employerAd.MaxSalary = ad.MaxSalary;
                    employerAd.MinSalary = ad.MinSalary;
                    employerAd.PublishDate = ad.PublishDate;
                    employerAd.CityId = ad.CityId;
                    employerAd.CityName = ad.CityName;
                    employerAd.EmployerId = ad.EmployerId;
                    employerAdList.Add(employerAd);
                }
            }
            return View(employerAdList);

        }

        public IActionResult OpenAd(int JobAdvertisementId)
        {
            if (_jobAdvertisementService.ActivateJobAdvertisement(JobAdvertisementId).Success)
            {
                return RedirectToAction("GetDeactiveAds", "PostedAdvertisements");
            }
            return RedirectToAction("GetDeactiveAds", "PostedAdvertisements");
        }

        public IActionResult UpdateAdvertisement(int JobAdvertisementId)
        {
            var citySelectList = new CitySelectList(_cityService);
            var cities = citySelectList.GetCities();
            ViewBag.cities = cities;
            ViewBag.jobAdvertisementId = JobAdvertisementId;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAdvertisement(EmployerJobAdvertisement jobAdvertisement)
        {
            var updatedAdvertisement = new EmployerJobAdvertisementDTO
            {
                CityId = jobAdvertisement.CityId,
                JobAdvertisementId = jobAdvertisement.JobAdvertisementId,
                JobDescription = jobAdvertisement.JobDescription,
                JobTitle = jobAdvertisement.JobTitle,
                MaxSalary = jobAdvertisement.MaxSalary,
                MinSalary = jobAdvertisement.MinSalary
            };
            if (_jobAdvertisementService.UpdateJobAdvertisement(updatedAdvertisement).Success)
            {
                return RedirectToAction("Index", "PostedAdvertisements");
            }
            return RedirectToAction("UpdateAdvertisement", "PostedAdvertisements",new { JobAdvertisementId  = jobAdvertisement.JobAdvertisementId});
        }
    }
}
