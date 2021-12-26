using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class JobAdvertisementService : IJobAdvertisementService
    {
        private readonly IJobAdvertisementDal _jobAdvertisementDal;
        public JobAdvertisementService(IJobAdvertisementDal jobAdvertisementDal)
        {
            _jobAdvertisementDal = jobAdvertisementDal;
        }
        public Result AddJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            if(jobAdvertisement.JobDescription==null || jobAdvertisement.JobTitle == null)
            {
                return new Result(false, "Please fill all informations about the job.");
            }
            if (jobAdvertisement.MinSalary > jobAdvertisement.MaxSalary)
            {
                return new Result(false, "Maximum Salary can not be less than Minimum Salary!");
            }
            jobAdvertisement.PublishDate = DateTime.Now;
            jobAdvertisement.IsActive = true;
            _jobAdvertisementDal.Add(jobAdvertisement);
            return new Result(true, "Job Advertisement Added.");
        }

        public Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            _jobAdvertisementDal.Delete(jobAdvertisement);
            return new Result(true, "Job Advertisement is deleted.");
        }

        public DataResult<List<JobAdvertisement>> GetAllJobAdvertisements()
        {
            return new DataResult<List<JobAdvertisement>>(_jobAdvertisementDal.GetAll(), true, "All inactive/active advertisements listed.");
        }

        public DataResult<JobAdvertisement> GetJobAdvertisementById(int id)
        {
            return new DataResult<JobAdvertisement>(_jobAdvertisementDal.GetById(id), true, "Job Advertisement is listed.");
        }

        public Result UpdateJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            _jobAdvertisementDal.Update(jobAdvertisement);
            return new Result(true, "Advertisement is updated.");
        }
    }
}
