using BusinessLayer.Utilities.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
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
