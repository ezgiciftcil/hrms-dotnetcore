﻿using BusinessLayer.Interfaces;
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
    public class EmployerController : Controller
    {
        private IEmployerService _employerService;
        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpPost("add_employer")]
        public Result Add([FromBody] Employer employer)
        {
            return _employerService.AddEmployer(employer);
        }

        [HttpPost("delete_employer")]
        public Result Delete([FromBody] Employer employer)
        {
            return _employerService.DeleteEmployer(employer);
        }

        [HttpPost("update_employer")]
        public Result Update([FromBody] Employer employer)
        {
            return _employerService.UpdateEmployer(employer);
        }

        [HttpGet("list_employers")]
        public DataResult<List<Employer>> GetAllCities()
        {
            return _employerService.GetAllEmployers();
        }

        [HttpPost("get_city")]
        public DataResult<Employer> GetCityById(int CityId)
        {
            return _employerService.GetEmployerById(CityId);
        }
    }
}