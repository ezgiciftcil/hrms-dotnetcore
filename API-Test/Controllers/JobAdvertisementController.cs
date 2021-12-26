using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAdvertisementController : Controller
    {
        private readonly IJobAdvertisementService _jobAdvertisementService;
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
        [HttpGet("list_jobAdvertisement")]
        public DataResult<List<JobAdvertisement>> GetAllJobAdvertisements()
        {
            return _jobAdvertisementService.GetAllJobAdvertisements();
        }
        [HttpPost("get_jobAdvertisemet")]
        public DataResult<JobAdvertisement> GetJobAdvertisementById(int id)
        {
            return _jobAdvertisementService.GetJobAdvertisementById(id);
        }
    }
}
