using BusinessLayer.Utilities.Results;
using EntityLayer;
using EntityLayer.DTO_s;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IExperienceService
    {
        Result AddExperience(ExperienceDTO experience);
        Result UpdateExperience(ExperienceDTO experience);
        Result DeleteExperience(int experienceId);
        DataResult<List<Experience>> GetAllExperiences();
        DataResult<Experience> GetExperienceById(int id);
        DataResult<List<Experience>> GetUserAllExperiences(int resumeId);
    }
}
