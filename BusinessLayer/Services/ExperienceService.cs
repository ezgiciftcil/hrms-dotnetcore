using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using EntityLayer.DTO_s;
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

        public Result AddExperience(ExperienceDTO experience)
        {
            if(experience.CompanyName==null || experience.JobDescription==null || experience.JobTitle==null)
            {
                return new Result(false, "Old Job Experience Details can not be Empty!");
            }
            var newExperience = new Experience
            {
                ResumeId = experience.ResumeId,
                CompanyName = experience.CompanyName,
                JobDescription = experience.JobDescription,
                JobTitle = experience.JobTitle,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate
            };
            _experienceDal.Add(newExperience);
            return new Result(true, "Experience Added");
        }

        public Result DeleteExperience(int experienceId)
        {
            var deletedExperience = new Experience
            {
                ExperienceId = experienceId
            };
            _experienceDal.Delete(deletedExperience);
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

        public DataResult<List<Experience>> GetUserAllExperiences(int resumeId)
        {
            return new DataResult<List<Experience>>(_experienceDal.GetUserAllExperiences(resumeId), true);
        }

        public Result UpdateExperience(ExperienceDTO experience)
        {
            var updatedExperience = new Experience
            {
                ExperienceId = experience.ExperienceId,
                CompanyName = experience.CompanyName,
                JobDescription = experience.JobDescription,
                JobTitle = experience.JobTitle,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate
            };
            _experienceDal.Update(updatedExperience);
            return new Result(true, "Experience Updated.");
        }
    }
}
