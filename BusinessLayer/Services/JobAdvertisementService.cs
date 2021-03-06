using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using EntityLayer.DTO_s;
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
        public Result AddJobAdvertisement(EmployerJobAdvertisementDTO jobAdvertisement)
        {
            if(jobAdvertisement.JobDescription==null || jobAdvertisement.JobTitle == null)
            {
                return new Result(false, "Please fill all informations about the job.");
            }
            if (jobAdvertisement.MinSalary > jobAdvertisement.MaxSalary)
            {
                return new Result(false, "Maximum Salary can not be less than Minimum Salary!");
            }
            var newJobAdvertisement = new JobAdvertisement
            {
                PublishDate = DateTime.Now,
                IsActive = true,
                CityId = jobAdvertisement.CityId,
                EmployerId = jobAdvertisement.EmployerId,
                JobDescription = jobAdvertisement.JobDescription,
                JobTitle = jobAdvertisement.JobTitle,
                MaxSalary = jobAdvertisement.MaxSalary,
                MinSalary = jobAdvertisement.MinSalary
            };
            _jobAdvertisementDal.Add(newJobAdvertisement);
            return new Result(true, "Job Advertisement Added.");
        }

        public Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            _jobAdvertisementDal.Delete(jobAdvertisement);
            return new Result(true, "Job Advertisement is deleted.");
        }

        public DataResult<List<JobAdvertisementDTO>> GetAllActiveJobAdvertisements()
        {
            return new DataResult<List<JobAdvertisementDTO>>(_jobAdvertisementDal.GetAllActiveJobAdvertisements(), true);
        }

        public DataResult<List<JobAdvertisement>> GetAllJobAdvertisements()
        {
            return new DataResult<List<JobAdvertisement>>(_jobAdvertisementDal.GetAll(), true, "All inactive/active advertisements listed.");
        }

        public DataResult<JobAdvertisement> GetJobAdvertisementById(int id)
        {
            return new DataResult<JobAdvertisement>(_jobAdvertisementDal.GetById(id), true, "Job Advertisement is listed.");
        }

        public DataResult<JobAdvertisementDetailDTO> GetJobAdvertisementDetailById(int JobAdvertisementId)
        {
            return new DataResult<JobAdvertisementDetailDTO>(_jobAdvertisementDal.GetJobAdvertisementDetailById(JobAdvertisementId), true);
        }

        public Result UpdateJobAdvertisement(EmployerJobAdvertisementDTO jobAdvertisement)
        {
            var updatedJobAdvertisement = new JobAdvertisement
            {
                CityId = jobAdvertisement.CityId,
                JobAdvertisementId = jobAdvertisement.JobAdvertisementId,
                IsActive = true,
                JobDescription = jobAdvertisement.JobDescription,
                JobTitle = jobAdvertisement.JobTitle,
                MaxSalary = jobAdvertisement.MaxSalary,
                MinSalary = jobAdvertisement.MinSalary
            };
            _jobAdvertisementDal.Update(updatedJobAdvertisement);
            return new Result(true, "Advertisement is updated.");
        }

        public bool CheckIfUserAppliedJob(int JobAdvertisementId, int JobSeekerId)
        {
            var check = _jobAdvertisementDal.CheckIfUserAppliedJob(JobAdvertisementId, JobSeekerId);
            if (check == 0)
            {
                return false;
            }
            return true;
        }
        public Result ApplyJobAd(int JobAdvertisementId, int JobSeekerId)
        {
            _jobAdvertisementDal.ApplyJobAd(JobAdvertisementId, JobSeekerId);
            return new Result(true, "Job Apply is Successfull!");
        }

        public DataResult<List<AppliedJobAdvertisementDTO>> GetAppliedJobAdvertisements(int JobSeekerId)
        {
            return new DataResult<List<AppliedJobAdvertisementDTO>>(_jobAdvertisementDal.GetAppliedJobAdvertisements(JobSeekerId), true);
        }

        public Result DeactiveJobAdvertisement(int JobAdvertisementId)
        {
            _jobAdvertisementDal.DeactiveJobAdvertisement(JobAdvertisementId);
            return new Result(true, "Deactivated");
        }

        public Result ActivateJobAdvertisement(int JobAdvertisementId)
        {
            _jobAdvertisementDal.ActivateJobAdvertisement(JobAdvertisementId);
            return new Result(true, "Activated");
        }

        public DataResult<List<EmployerJobAdvertisementDTO>> GetEmployerAllJobAdvertisements(int EmployerId)
        {
            return new DataResult<List<EmployerJobAdvertisementDTO>>(_jobAdvertisementDal.GetEmployerAllJobAdvertisements(EmployerId), true);
        }

        public DataResult<List<CandidateDTO>> GetAllUsersAppliedJob(int JobAdvertisementId)
        {
            return new DataResult<List<CandidateDTO>>(_jobAdvertisementDal.GetAllUsersAppliedJob(JobAdvertisementId), true);
        }
    }
}
