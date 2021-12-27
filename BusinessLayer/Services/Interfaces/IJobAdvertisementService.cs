using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IJobAdvertisementService
    {
        Result AddJobAdvertisement(JobAdvertisement jobAdvertisement);
        Result UpdateJobAdvertisement(JobAdvertisement jobAdvertisement);
        Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement);
        DataResult<List<JobAdvertisement>> GetAllJobAdvertisements();
        DataResult<JobAdvertisement> GetJobAdvertisementById(int id);
    }
}
