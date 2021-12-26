using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IJobSeekerService
    {
        Result AddJobSeeker(JobSeeker jobSeeker);
        Result UpdateJobSeeker(JobSeeker jobSeeker);
        Result DeleteJobSeeker(JobSeeker jobSeeker);
        DataResult<List<JobSeeker>> GetAllJobSeekers();
        DataResult<JobSeeker> GetJobSeekerById(int id);
    }
}
