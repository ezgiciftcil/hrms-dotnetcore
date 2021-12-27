using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : Controller
    {
        private readonly IJobSeekerService _jobSeekerService;
        public JobSeekerController(IJobSeekerService jobSeekerService)
        {
            _jobSeekerService = jobSeekerService;
        }

        [HttpPost("add_jobSeeker")]
        public Result AddJobSeeker(JobSeeker jobSeeker)
        {
            return _jobSeekerService.AddJobSeeker(jobSeeker);
        }
        [HttpPost("update_jobSeeker")]
        public Result UpdateJobSeeker(JobSeeker jobSeeker)
        {
            return _jobSeekerService.UpdateJobSeeker(jobSeeker);
        }
        [HttpPost("delete_jobSeeker")]
        public Result DeleteJobSeeker(JobSeeker jobSeeker)
        {
            return _jobSeekerService.DeleteJobSeeker(jobSeeker);
        }
        [HttpGet("list_jobSeeker")]
        public DataResult<List<JobSeeker>> GetAllJobSeekers()
        {
            return _jobSeekerService.GetAllJobSeekers();
        }
        [HttpPost("get_jobSeeker")]
        public DataResult<JobSeeker> GetJobSeekerById(int id)
        {
            return _jobSeekerService.GetJobSeekerById(id);
        }
    }
}
