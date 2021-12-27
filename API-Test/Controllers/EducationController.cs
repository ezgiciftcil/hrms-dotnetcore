using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : Controller
    {
        private readonly IEducationService educationService;
        public EducationController(IEducationService _educationService)
        {
            educationService = _educationService;
        }

        [HttpPost("add_education")]
        public Result Add([FromBody] Education education)
        {
            return educationService.AddEducation(education);
        }

        [HttpPost("delete_education")]
        public Result Delete([FromBody] Education education)
        {
            return educationService.DeleteEducation(education);
        }

        [HttpPost("update_education")]
        public Result Update([FromBody] Education education)
        {
            return educationService.UpdateEducation(education);
        }

        [HttpGet("list_educations")]
        public DataResult<List<Education>> GetAllEducations()
        {
            return educationService.GetAllEducations();
        }

        [HttpPost("get_education")]
        public DataResult<Education> GetEducationById(int educationId)
        {
            return educationService.GetEducationById(educationId);
        }

    }
}
