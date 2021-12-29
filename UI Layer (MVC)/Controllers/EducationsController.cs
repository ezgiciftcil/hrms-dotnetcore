using BusinessLayer.Services.Interfaces;
using EntityLayer.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class EducationsController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IResumeService _resumeService;
        public EducationsController(IEducationService educationService, IResumeService resumeService)
        {
            _educationService = educationService;
            _resumeService = resumeService;
        }
        public IActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var resumeId = _resumeService.GetJobSeekerResumeId(userId);
            var allEducation = _educationService.GetUserAllEducations(resumeId).Data;
            var educationList = new List<Education>();
            foreach (var ed in allEducation)
            {
                var newEducation = new Education
                {
                    UniversityName = ed.UniversityName,
                    DepartmentName=ed.DepartmentName,
                    GPA=ed.GPA,
                    StartDate=ed.StartDate,
                    FinishDate=ed.FinishDate,
                    EducationId=ed.EducationId,
                    ResumeId=ed.ResumeId
                };
                educationList.Add(newEducation);
            }
            return View(educationList);
        }

        public IActionResult DeleteEducation(int educationId)
        {

            if (_educationService.DeleteEducation(educationId).Success)
            {
                return RedirectToAction("Index", "Educations");
            }
            return RedirectToAction("Index", "Educations");
        }

        public IActionResult EditEducation(int educationId)
        {
            var editedEducation = new Education
            {
                EducationId = educationId
        };
            return View(editedEducation);
        }
        [HttpPost]
        public IActionResult EditEducation(Education education)
        {
            var editedEducation = new EducationDTO
            {
                EducationId = education.EducationId,
                UniversityName = education.UniversityName,
                DepartmentName = education.DepartmentName,
                GPA = education.GPA,
                StartDate = education.StartDate,
                FinishDate = education.FinishDate
            };

            if (_educationService.UpdateEducation(editedEducation).Success)
            {
                return RedirectToAction("Index", "Educations");
            }
            return RedirectToAction("EditEducation", "Educations", new { educationId = education.EducationId});
        }

        public IActionResult AddNewEducation()
        {
            var jobSeekerId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var resumeId = _resumeService.GetJobSeekerResumeId(jobSeekerId);
            var newEducation = new Education
            {
                ResumeId = resumeId
            };
            return View(newEducation);
        }

        [HttpPost]
        public IActionResult AddNewEducation(Education education)
        {
            var newEducation = new EducationDTO
            {
                ResumeId = education.ResumeId,
                UniversityName = education.UniversityName,
                DepartmentName = education.DepartmentName,
                GPA = education.GPA,
                StartDate = education.StartDate,
                FinishDate = education.FinishDate
            };

            if (_educationService.AddEducation(newEducation).Success)
            {
                return RedirectToAction("Index", "Educations");
            }
            return RedirectToAction("AddNewEducation", "Educations");
        }

    }
}
