using BusinessLayer.Interfaces;
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
    public class JobTitleController : Controller
    {
        private IJobTitleService _jobTitleService;
        public JobTitleController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        [HttpPost("add_jobTitle")]
        public Result AddJobTitle([FromBody] JobTitle jobTitle)
        {
            return _jobTitleService.AddJobTitle(jobTitle);
        }
        [HttpPost("update_jobTitle")]
        public Result UpdateJobTitle([FromBody] JobTitle jobTitle)
        {
            return _jobTitleService.UpdateJobTitle(jobTitle);
        }
        [HttpPost("delete_jobTitle")]
        public Result DeleteJobTitle([FromBody] JobTitle jobTitle)
        {
            return _jobTitleService.DeleteJobTitle(jobTitle);
        }
        [HttpGet("list_jobTitles")]
        public DataResult<List<JobTitle>> GetAllJobTitles()
        {
            return _jobTitleService.GetAllJobTitles();
        }
        [HttpPost("get_jobTitle")]
        public DataResult<JobTitle> GetJobTitleById(int id)
        {
            return _jobTitleService.GetJobTitleById(id);
        }
    }
}
