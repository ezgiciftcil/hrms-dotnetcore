using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpPost("add_experience")]
        public Result AddExperience(Experience experience)
        {
            return _experienceService.AddExperience(experience);
        }
        [HttpPost("update_experience")]
        public Result UpdateExperience(Experience experience)
        {
            return _experienceService.UpdateExperience(experience);
        }
        [HttpPost("delete_experience")]
        public Result DeleteExperience(Experience experience)
        {
            return _experienceService.DeleteExperience(experience);
        }
        [HttpGet("list_experiences")]
        public DataResult<List<Experience>> GetAllExperience()
        {
            return _experienceService.GetAllExperiences();
        }
        [HttpPost("get_experience")]
        public DataResult<Experience> GetExperienceById(int id)
        {
            return _experienceService.GetExperienceById(id);
        }
    }
}
