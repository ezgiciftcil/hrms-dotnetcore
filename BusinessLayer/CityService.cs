using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CityService:ICityService
    {
        private ICityDal _cityDal;
        public CityService()
        {

        }
        public CityService(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public Result AddCity(City city)
        {
            _cityDal.Add(city);
            return new Result(true, "Şehir eklendi.");
        }

        public Result DeleteCity(City city)
        {
            _cityDal.Delete(city);
            return new Result(true, "Şehir silindi.");
        }

        public DataResult<List<City>> GetAllCities()
        {
            return new DataResult<List<City>>(_cityDal.GetAll(), true, "Şehirler listelendi.");
        }

        public DataResult<City> GetCityById(int id)
        {
            return new DataResult<City>(_cityDal.GetById(id), true, "Şehir getirildi.");
        }

        public Result UpdateCity(City city)
        {
            _cityDal.Update(city);
            return new Result(true, "Şehir güncellendi."); 
        }
    }
}
