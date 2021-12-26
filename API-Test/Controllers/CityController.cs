using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }

        [HttpPost("add_city")]
        public Result Add([FromBody] City city)
        {
            return cityService.AddCity(city);
        }

        [HttpPost("delete_city")]
        public Result Delete([FromBody] City city)
        {
            return cityService.DeleteCity(city);
        }

        [HttpPost("update_city")]
        public Result Update([FromBody] City city)
        {
            return cityService.UpdateCity(city);
        }

        [HttpGet("list_cities")]
        public DataResult<List<City>> GetAllCities()
        {
            return cityService.GetAllCities();
        }

        [HttpPost("get_city")]
        public DataResult<City> GetCityById(int CityId)
        {
            return cityService.GetCityById(CityId);
        }

    }
}
