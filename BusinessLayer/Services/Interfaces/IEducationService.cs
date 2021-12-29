using BusinessLayer.Utilities.Results;
using EntityLayer;
using EntityLayer.DTO_s;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IEducationService
    {
        Result AddEducation(EducationDTO education);
        Result UpdateEducation(EducationDTO education);
        Result DeleteEducation(int educationId);
        DataResult<List<Education>> GetAllEducations();
        DataResult<Education> GetEducationById(int id);
        DataResult<List<Education>> GetUserAllEducations(int resumeId);
    }
}
