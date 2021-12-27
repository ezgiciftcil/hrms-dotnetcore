using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost("add_skill")]
        public Result AddSkill(Skill skill)
        {
            return _skillService.AddSkill(skill);
        }
        [HttpPost("update_skill")]
        public Result UpdateSkill(Skill skill)
        {
            return _skillService.UpdateSkill(skill);
        }
        [HttpPost("delete_skill")]
        public Result DeleteJobSeeker(Skill skill)
        {
            return _skillService.DeleteSkill(skill);
        }
        [HttpGet("list_skills")]
        public DataResult<List<Skill>> GetAllJobSeekers()
        {
            return _skillService.GetAllSkills();
        }
        [HttpPost("get_skill")]
        public DataResult<Skill> GetSkillById(int id)
        {
            return _skillService.GetSkillById(id);
        }
    }
}
