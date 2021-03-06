using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class ActiveAdvertisementsController : Controller
    {
        private readonly IJobAdvertisementService _jobAdvertisementService;
        public ActiveAdvertisementsController(IJobAdvertisementService jobAdvertisementService)
        {
            _jobAdvertisementService = jobAdvertisementService;
        }
        public IActionResult Index()
        {
            var activeAds = _jobAdvertisementService.GetAllActiveJobAdvertisements().Data;
            var adsToDisplay = new List<JobAdvertisement>();
            foreach (var activeAd in activeAds)
            {

                var jobAd = new JobAdvertisement();
                jobAd.CompanyName = activeAd.CompanyName;
                jobAd.JobAdvertisementId = activeAd.JobAdvertisementId;
                jobAd.JobTitle = activeAd.JobTitle;
                adsToDisplay.Add(jobAd);
            }
            return View(adsToDisplay);
        }

        public IActionResult JobAdDetail(int jobAdvId)
        {
            var jobAdvDetails = _jobAdvertisementService.GetJobAdvertisementDetailById(jobAdvId).Data;
            var jobAdvModel = new JobAdvertisementDetail
            {
                CityName = jobAdvDetails.CityName,
                CompanyName = jobAdvDetails.CompanyName,
                CompanyWebsite = jobAdvDetails.CompanyWebsite,
                JobDescription = jobAdvDetails.JobDescription,
                JobTitle = jobAdvDetails.JobTitle,
                MaxSalary = jobAdvDetails.MaxSalary,
                PublishDate = jobAdvDetails.PublishDate,
                MinSalary = jobAdvDetails.MinSalary,
                JobAdvertisementId = jobAdvId
            };

            return View(jobAdvModel);
        }

        public IActionResult ApplyAdvertisement(int jobAdvId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            if(_jobAdvertisementService.CheckIfUserAppliedJob(jobAdvId, userId)){
                return RedirectToAction("JobAdDetail", "ActiveAdvertisements",new { jobAdvId=jobAdvId } );
            }
            if (_jobAdvertisementService.ApplyJobAd(jobAdvId, userId).Success)
            {
                return RedirectToAction("Index", "ActiveAdvertisements");
            }
            return RedirectToAction("JobAdDetail", "ActiveAdvertisements", new { jobAdvId = jobAdvId });
        }
    }
}
