using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class PostedAdvertisements : Controller
    {
        private readonly IJobAdvertisementService _jobAdvertisementService;
        public PostedAdvertisements(IJobAdvertisementService jobAdvertisementService)
        {
            _jobAdvertisementService = jobAdvertisementService;
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
    }
}
