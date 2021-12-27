using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationDal _educationDal;
        public EducationService(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }
        public Result AddEducation(Education education)
        {
            if(education.DepartmentName==null || education.UniversityName == null)
            {
                return new Result(false, "Please fill your university informations correctly.");
            }
            _educationDal.Add(education);
            return new Result(true, "Education added.");
        }

        public Result DeleteEducation(Education education)
        {
            _educationDal.Delete(education);
            return new Result(true, "Education deleted.");
        }

        public DataResult<List<Education>> GetAllEducations()
        {
            return new DataResult<List<Education>>(_educationDal.GetAll(), true);
        }

        public DataResult<Education> GetEducationById(int id)
        {
            return new DataResult<Education>(_educationDal.GetById(id), true);
        }

        public Result UpdateEducation(Education education)
        {
            _educationDal.Update(education);
            return new Result(true, "Education updated.");
        }
    }
}
