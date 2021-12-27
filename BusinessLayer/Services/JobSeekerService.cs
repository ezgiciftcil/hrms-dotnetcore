using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class JobSeekerService : IJobSeekerService
    {
        private readonly IJobSeekerDal _jobSeekerDal;
        public JobSeekerService(IJobSeekerDal jobSeekerDal)
        {
            _jobSeekerDal = jobSeekerDal;
        }

        public Result AddJobSeeker(JobSeeker jobSeeker)
        {
            if(jobSeeker.FirstName==null || jobSeeker.LastName == null)
            {
                return new Result(false, "Please fill your name and lastname.");
            }
            if (!(jobSeeker.PhoneNumber.Length != 11 || jobSeeker.PhoneNumber.Length != 10))
            {
                return new Result(false, "Please enter your phone number carefully with 11 or 10 length");
            }
            _jobSeekerDal.Add(jobSeeker);
            return new Result(true, "JobSeeker added.");
        }

        public Result DeleteJobSeeker(JobSeeker jobSeeker)
        {
            _jobSeekerDal.Delete(jobSeeker);
            return new Result(true, "JobSeeker deleted.");
        }

        public DataResult<List<JobSeeker>> GetAllJobSeekers()
        {
            return new DataResult<List<JobSeeker>>(_jobSeekerDal.GetAll(), true, "All inactive/active job seekers are listed.");
        }

        public DataResult<JobSeeker> GetJobSeekerById(int id)
        {
            return new DataResult<JobSeeker>(_jobSeekerDal.GetById(id), true, "Job Seeker is listed.");
        }

        public Result UpdateJobSeeker(JobSeeker jobSeeker)
        {
            _jobSeekerDal.Update(jobSeeker);
            return new Result(true, "Job Seeker informations are updated.");
        }
    }
}
