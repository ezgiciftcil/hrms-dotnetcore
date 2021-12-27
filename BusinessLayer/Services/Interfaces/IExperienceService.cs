using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IExperienceService
    {
        Result AddExperience(Experience experience);
        Result UpdateExperience(Experience experience);
        Result DeleteExperience(Experience experience);
        DataResult<List<Experience>> GetAllExperiences();
        DataResult<Experience> GetExperienceById(int id);
    }
}
