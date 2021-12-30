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
    public class CandidatesController : Controller
    {
        private readonly IJobAdvertisementService _jobAdvertisement;
        private readonly ISkillService _skillService;
        private readonly IExperienceService _experienceService;
        private readonly IEducationService _educationService;
        public CandidatesController(IJobAdvertisementService jobAdvertisement, ISkillService skillService, IExperienceService experienceService, IEducationService educationService)
        {
            _jobAdvertisement = jobAdvertisement;
            _skillService = skillService;
            _experienceService = experienceService;
            _educationService = educationService;
        }
        public IActionResult Index(int JobAdvertisementId)
        {
            var candidates = _jobAdvertisement.GetAllUsersAppliedJob(JobAdvertisementId).Data;
            var candidateList = new List<Candidate>();
            foreach (var candidate in candidates)
            {
                var getCandidate = new Candidate();
                getCandidate.Email = candidate.Email;
                getCandidate.FirstName = candidate.FirstName;
                getCandidate.JobAdvertisementId = candidate.JobAdvertisementId;
                getCandidate.JobSeekerId = candidate.JobSeekerId;
                getCandidate.LastName = candidate.LastName;
                getCandidate.PhoneNumber = candidate.PhoneNumber;
                getCandidate.ResumeId = candidate.ResumeId;
                candidateList.Add(getCandidate);
            }
            return View(candidateList);
        }

        public IActionResult GetCandidateExperiences(int ResumeId,string Candidate,int JobAdvertisementId)
        {
            ViewBag.ResumeId = ResumeId;
            ViewBag.Candidate = Candidate;
            ViewBag.JobAdvertisementId = JobAdvertisementId;
            var allExperiences = _experienceService.GetUserAllExperiences(ResumeId).Data;
            var experienceList = new List<Experience>();
            foreach (var experience in allExperiences)
            {
                var newExperience = new Experience
                {
                    CompanyName = experience.CompanyName,
                    JobDescription = experience.JobDescription,
                    JobTitle = experience.JobTitle,
                    StartDate = experience.StartDate,
                    EndDate = experience.EndDate,
                    ExperienceId = experience.ExperienceId,
                    ResumeId = experience.ResumeId
                };
                experienceList.Add(newExperience);
            }
            return View(experienceList);
        }

        public IActionResult GetCandidateEducations(int ResumeId,string Candidate, int JobAdvertisementId)
        {
            ViewBag.ResumeId = ResumeId;
            ViewBag.Candidate = Candidate;
            ViewBag.JobAdvertisementId = JobAdvertisementId;
            var allEducations = _educationService.GetUserAllEducations(ResumeId).Data;
            var educationList = new List<Education>();
            foreach (var ed in allEducations)
            {
                var newEducation = new Education
                {
                    UniversityName = ed.UniversityName,
                    DepartmentName = ed.DepartmentName,
                    GPA = ed.GPA,
                    StartDate = ed.StartDate,
                    FinishDate = ed.FinishDate,
                    EducationId = ed.EducationId,
                    ResumeId = ed.ResumeId
                };
                educationList.Add(newEducation);
            }
            return View(educationList);
        }

        public IActionResult GetCandidateSkills(int ResumeId,string Candidate, int JobAdvertisementId)
        {
            ViewBag.ResumeId = ResumeId;
            ViewBag.Candidate = Candidate;
            ViewBag.JobAdvertisementId = JobAdvertisementId;
            var allSkills = _skillService.GetUserAllSkills(ResumeId).Data;
            var skillList = new List<Skill>();
            foreach (var skill in allSkills)
            {
                var newSkill = new Skill
                {
                    ResumeId = skill.ResumeId,
                    SkillId = skill.SkillId,
                    SkillName = skill.SkillName
                };
                skillList.Add(newSkill);
            }
            return View(skillList);
        }

        
    }
}
