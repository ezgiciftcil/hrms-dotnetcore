using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IEducationService
    {
        Result AddEducation(Education education);
        Result UpdateEducation(Education education);
        Result DeleteEducation(Education education);
        DataResult<List<Education>> GetAllEducations();
        DataResult<Education> GetEducationById(int id);
    }
}
