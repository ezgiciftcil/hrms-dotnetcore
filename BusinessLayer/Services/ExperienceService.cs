using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceDal _experienceDal;
        public ExperienceService(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public Result AddExperience(Experience experience)
        {
            if(experience.CompanyName==null || experience.JobDescription==null || experience.JobTitle==null)
            {
                return new Result(false, "Old Job Experience Details can not be Empty!");
            }
            _experienceDal.Add(experience);
            return new Result(true, "Experience Added");
        }

        public Result DeleteExperience(Experience experience)
        {
            _experienceDal.Delete(experience);
            return new Result(true, "Experience Deleted.");
        }

        public DataResult<List<Experience>> GetAllExperiences()
        {
            return new DataResult<List<Experience>>(_experienceDal.GetAll(), true);
        }

        public DataResult<Experience> GetExperienceById(int id)
        {
            return new DataResult<Experience>(_experienceDal.GetById(id), true);
        }

        public Result UpdateExperience(Experience experience)
        {
            _experienceDal.Update(experience);
            return new Result(true, "Experience Updated.");
        }
    }
}
