using EntityLayer;
using EntityLayer.DTO_s;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IJobAdvertisementDal:IGenericDal<JobAdvertisement>
    {
        List<JobAdvertisementDTO> GetAllActiveJobAdvertisements();
        JobAdvertisementDetailDTO GetJobAdvertisementDetailById(int JobAdvertisementId);
        int CheckIfUserAppliedJob(int JobAdvertisementId, int JobSeekerId);
        void ApplyJobAd(int JobAdvertisementId, int JobSeekerId);
        List<AppliedJobAdvertisementDTO> GetAppliedJobAdvertisements(int JobSeekerId);
    }
}
