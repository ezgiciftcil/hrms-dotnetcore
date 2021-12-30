using BusinessLayer.Utilities.Results;
using EntityLayer;
using EntityLayer.DTO_s;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IJobAdvertisementService
    {
        Result AddJobAdvertisement(EmployerJobAdvertisementDTO jobAdvertisement);
        Result UpdateJobAdvertisement(EmployerJobAdvertisementDTO jobAdvertisement);
        Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement);
        DataResult<List<JobAdvertisement>> GetAllJobAdvertisements();
        DataResult<JobAdvertisement> GetJobAdvertisementById(int id);
        DataResult<List<JobAdvertisementDTO>> GetAllActiveJobAdvertisements();
        DataResult<JobAdvertisementDetailDTO> GetJobAdvertisementDetailById(int JobAdvertisementId);
        bool CheckIfUserAppliedJob(int JobAdvertisementId, int JobSeekerId);
        Result ApplyJobAd(int JobAdvertisementId, int JobSeekerId);
        DataResult<List<AppliedJobAdvertisementDTO>> GetAppliedJobAdvertisements(int JobSeekerId);
        Result DeactiveJobAdvertisement(int JobAdvertisementId);
        Result ActivateJobAdvertisement(int JobAdvertisementId);
        DataResult<List<EmployerJobAdvertisementDTO>> GetEmployerAllJobAdvertisements(int EmployerId);
    }
}
