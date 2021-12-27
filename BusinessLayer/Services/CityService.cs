using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class CityService:ICityService
    {
        private readonly ICityDal _cityDal;
        public CityService(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public Result AddCity(City city)
        {
            _cityDal.Add(city);
            return new Result(true, "City is added.");
        }

        public Result DeleteCity(City city)
        {
            _cityDal.Delete(city);
            return new Result(true, "City is deleted.");
        }

        public DataResult<List<City>> GetAllCities()
        {
            return new DataResult<List<City>>(_cityDal.GetAll(), true, "Cities are listed");
        }

        public DataResult<City> GetCityById(int id)
        {
            return new DataResult<City>(_cityDal.GetById(id), true, "City is listed");
        }

        public Result UpdateCity(City city)
        {
            _cityDal.Update(city);
            return new Result(true, "City is updated."); 
        }
    }
}
