using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using EntityLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAdvertisementController : Controller
    {
        private IJobAdvertisementService _jobAdvertisementService;
        public JobAdvertisementController(IJobAdvertisementService jobAdvertisementService)
        {
            _jobAdvertisementService = jobAdvertisementService;
        }
        [HttpPost("add_jobAdvertisement")]
        public Result AddJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            return _jobAdvertisementService.AddJobAdvertisement(jobAdvertisement);
        }
        [HttpPost("update_jobAdvertisement")]
        public Result UpdateJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            return _jobAdvertisementService.UpdateJobAdvertisement(jobAdvertisement);
        }
        [HttpPost("delete_jobAdvertisement")]
        public Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            return _jobAdvertisementService.DeleteJobAdvertisement(jobAdvertisement);
        }
        [HttpGet("list_jobAdvertisements")]
        public DataResult<List<JobAdvertisement>> GetAllJobAdvertisements()
        {
            return _jobAdvertisementService.GetAllJobAdvertisements();
        }
        [HttpPost("get_jobAdvertisement")]
        public DataResult<JobAdvertisement> GetJobAdvertisementById(int id)
        {
            return _jobAdvertisementService.GetJobAdvertisementById(id);
        }
    }
}
