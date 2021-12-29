using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UI_Layer__MVC_.Models;

namespace UI_Layer__MVC_.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly IResumeService _resumeService;
        public SkillsController(ISkillService skillService,IResumeService resumeService)
        {
            _resumeService = resumeService;
            _skillService = skillService;
        }
        public IActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var allSkills = _skillService.GetUserAllSkills(userId).Data;
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


        public IActionResult DeleteSkill(int skillId)
        {
            if (_skillService.DeleteSkill(skillId).Success)
            {
                return RedirectToAction("Index", "Skills");
            }
            return RedirectToAction("Index", "Skills");
        }

        public IActionResult EditSkill(int skillId)
        {
            var skill = new Skill
            {
                SkillId = skillId
            };
            return View(skill);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            if (_skillService.UpdateSkill(skill.SkillId, skill.SkillName).Success)
            {
                return RedirectToAction("Index", "Skills");
            }
            return RedirectToAction("EditSkill", "Skills", new { skillId = skill.SkillId });
        }

        public IActionResult AddNewSkill()
        {
            var jobSeekerId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionInfo.SessionUserId));
            var resumeId = _resumeService.GetJobSeekerResumeId(jobSeekerId);
            var newSkill = new Skill {
                ResumeId = resumeId
        };
            return View(newSkill);
        }

        [HttpPost]
        public IActionResult AddNewSkill(Skill skill)
        {
            if (_skillService.AddSkill(skill.ResumeId,skill.SkillName).Success)
            {
                return RedirectToAction("Index", "Skills");
            }
            return RedirectToAction("AddNewSkill", "Skills");
        }
    }
}
