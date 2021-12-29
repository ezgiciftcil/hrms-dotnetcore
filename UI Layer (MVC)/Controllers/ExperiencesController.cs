using BusinessLayer.Services.Interfaces;
using EntityLayer.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class ExperiencesController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IResumeService _resumeService;
        public ExperiencesController(IExperienceService experienceService, IResumeService resumeService)
        {
            _experienceService = experienceService;
            _resumeService = resumeService;
        }
        public IActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var resumeId = _resumeService.GetJobSeekerResumeId(userId);
            var allExperiences = _experienceService.GetUserAllExperiences(resumeId).Data;
            var experienceList = new List<Experience>();
            foreach (var experience in allExperiences)
            {
                var newExperience = new Experience
                {
                    CompanyName=experience.CompanyName,
                    JobDescription=experience.JobDescription,
                    JobTitle=experience.JobTitle,
                    StartDate=experience.StartDate,
                    EndDate=experience.EndDate,
                    ExperienceId=experience.ExperienceId,
                    ResumeId=experience.ResumeId
                };
                experienceList.Add(newExperience);
            }
            return View(experienceList);
        }

        public IActionResult DeleteExperience(int experienceId)
        {

            if (_experienceService.DeleteExperience(experienceId).Success)
            {
                return RedirectToAction("Index", "Experiences");
            }
            return RedirectToAction("Index", "Experiences");
        }

        public IActionResult EditExperience(int experienceId)
        {
            var editedExperience = new Experience
            {
                ExperienceId = experienceId
            };
            return View(editedExperience);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            var editedExperience = new ExperienceDTO
            {
                CompanyName = experience.CompanyName,
                JobDescription = experience.JobDescription,
                JobTitle = experience.JobTitle,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,
                ExperienceId = experience.ExperienceId
            };

            if (_experienceService.UpdateExperience(editedExperience).Success)
            {
                return RedirectToAction("Index", "Experiences");
            }
            return RedirectToAction("EditExperience", "Experiences", new { experienceId = experience.ExperienceId });
        }

        public IActionResult AddNewExperience()
        {
            var jobSeekerId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var resumeId = _resumeService.GetJobSeekerResumeId(jobSeekerId);
            var newExperience = new Experience
            {
                ResumeId = resumeId
            };
            return View(newExperience);
        }

        [HttpPost]
        public IActionResult AddNewExperience(Experience experience)
        {
            var newExperience = new ExperienceDTO
            {
                CompanyName = experience.CompanyName,
                JobDescription = experience.JobDescription,
                JobTitle = experience.JobTitle,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,
                ResumeId = experience.ResumeId
            };

            if (_experienceService.AddExperience(newExperience).Success)
            {
                return RedirectToAction("Index", "Experiences");
            }
            return RedirectToAction("AddNewExperience", "Experiences");
        }

    }
}
