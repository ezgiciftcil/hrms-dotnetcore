using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class AppliedAdvertisementsController : Controller
    {

        private readonly IJobAdvertisementService _jobAdvertisementService;
        public AppliedAdvertisementsController(IJobAdvertisementService jobAdvertisementService)
        {
            _jobAdvertisementService = jobAdvertisementService;
        }
        public IActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var appliedJobAds = _jobAdvertisementService.GetAppliedJobAdvertisements(userId).Data;
            var jobAdList = new List<AppliedJobAdvertisement>();
            foreach (var ad in appliedJobAds)
            {
                var jobAd = new AppliedJobAdvertisement
                {
                    ApplyDate = ad.ApplyDate,
                    CompanyName = ad.CompanyName,
                    JobTitle = ad.JobTitle
                };
                jobAdList.Add(jobAd);
            }
            return View(jobAdList);
        }
    }
}
