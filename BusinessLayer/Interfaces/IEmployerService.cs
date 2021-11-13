using BusinessLayer.Utilities.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
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
