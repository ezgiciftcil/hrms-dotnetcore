using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICityService
    {
        Result AddCity(City city);
        Result UpdateCity(City city);
        Result DeleteCity(City city);
        DataResult<List<City>> GetAllCities();
        DataResult<City> GetCityById(int id);
    }
}
