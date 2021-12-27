using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
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
    public class ResumeController : Controller
    {
        private readonly IResumeService resumeService;
        public ResumeController(IResumeService _resumeService)
        {
            resumeService = _resumeService;
        }

        [HttpPost("add_resume")]
        public Result Add([FromBody] Resume resume)
        {
            return resumeService.AddResume(resume);
        }

        [HttpPost("delete_resume")]
        public Result Delete([FromBody] Resume resume)
        {
            return resumeService.DeleteResume(resume);
        }

        [HttpPost("update_resume")]
        public Result Update([FromBody] Resume resume)
        {
            return resumeService.UpdateResume(resume);
        }

        [HttpGet("list_resumes")]
        public DataResult<List<Resume>> GetAllResumes()
        {
            return resumeService.GetAllResumes();
        }

        [HttpPost("get_resume")]
        public DataResult<Resume> GetResumeById(int ResumeId)
        {
            return resumeService.GetResumeById(ResumeId);
        }

    }
}
