using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class EmployerService:IEmployerService
    {
        private readonly IEmployerDal _employerDal;
        public EmployerService(IEmployerDal employerDal)
        {
            _employerDal = employerDal;
        }

        public Result AddEmployer(Employer employer)
        {
            if(employer.CompanyName==null || employer.CompanyName.Length < 2)
            {
                return new Result(false, "Please fill the company name!");
            }
            if (employer.CompanyWebsite == null)
            {
                return new Result(false, "Please fill the company website!");
            }
            if(!(employer.ContactNumber.Length!=11 || employer.ContactNumber.Length != 10))
            {
                return new Result(false, "Please enter your company's contact number carefully with 11 or 10 length");
            }
            else
            {
                _employerDal.Add(employer);
                return new Result(true, "İş yerinizin üyeliği açıldı");
            }

        }

        public Result DeleteEmployer(Employer employer)
        {
            _employerDal.Delete(employer);
            return new Result(true, "Employer is deleted.");
        }

        public DataResult<List<Employer>> GetAllEmployers()
        {
            return new DataResult<List<Employer>>(_employerDal.GetAll(), true, "All active/inactive employers are listed.");
        }

        public DataResult<Employer> GetEmployerById(int id)
        {
            return new DataResult<Employer>(_employerDal.GetById(id), true, "Employer is selected.");
        }

        public Result UpdateEmployer(Employer employer)
        {
            _employerDal.Update(employer);
            return new Result(true, "Employer informations are updated.");
        }
    }
}
