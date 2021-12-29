using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using EntityLayer.DTO_s;
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
        public Result AddEducation(EducationDTO education)
        {
            if(education.DepartmentName==null || education.UniversityName == null)
            {
                return new Result(false, "Please fill your university informations correctly.");
            }
            var newEducation = new Education
            {
                ResumeId = education.ResumeId,
                UniversityName = education.UniversityName,
                DepartmentName = education.DepartmentName,
                GPA = education.GPA,
                FinishDate = education.FinishDate,
                StartDate = education.StartDate
            };
            _educationDal.Add(newEducation);
            return new Result(true, "Education added.");
        }

        public Result DeleteEducation(int educationId)
        {
            var deletedEducation = new Education
            {
                EducationId = educationId
            };
            _educationDal.Delete(deletedEducation);
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

        public DataResult<List<Education>> GetUserAllEducations(int resumeId)
        {
            return new DataResult<List<Education>>(_educationDal.GetUserAllEducations(resumeId), true);
        }

        public Result UpdateEducation(EducationDTO education)
        {
            var updatedEducation = new Education
            {
                EducationId = education.EducationId,
                UniversityName = education.UniversityName,
                DepartmentName = education.DepartmentName,
                GPA = education.GPA,
                FinishDate = education.FinishDate,
                StartDate = education.StartDate
            };
            _educationDal.Update(updatedEducation);
            return new Result(true, "Education updated.");
        }
    }
}
