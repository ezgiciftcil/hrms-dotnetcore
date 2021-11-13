using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class JobAdvertisementService : IJobAdvertisementService
    {
        public Result AddJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            throw new NotImplementedException();
        }

        public Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<JobAdvertisement>> GetAllJobAdvertisements()
        {
            throw new NotImplementedException();
        }

        public DataResult<City> GetJobAdvertisementById(int id)
        {
            throw new NotImplementedException();
        }

        public Result UpdateJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            throw new NotImplementedException();
        }
    }
}
