using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IEmployerService
    {
        Result AddEmployer(Employer employer);
        Result UpdateEmployer(Employer employer);
        Result DeleteEmployer(Employer employer);
        DataResult<List<Employer>> GetAllEmployers();
        DataResult<Employer> GetEmployerById(int id);
    }
}
