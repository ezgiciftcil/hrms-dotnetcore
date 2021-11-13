using BusinessLayer.Utilities.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IJobAdvertisementService
    {
        Result AddJobAdvertisement(JobAdvertisement jobAdvertisement);
        Result UpdateJobAdvertisement(JobAdvertisement jobAdvertisement);
        Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement);
        DataResult<List<JobAdvertisement>> GetAllJobAdvertisements();
        DataResult<City> GetJobAdvertisementById(int id);
    }
}
