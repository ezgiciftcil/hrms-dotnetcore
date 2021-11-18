using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interface;
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
        private IJobAdvertisementDal _jobAdvertisementDal;
        public JobAdvertisementService(IJobAdvertisementDal jobAdvertisementDal)
        {
            _jobAdvertisementDal = jobAdvertisementDal;
        }
        public Result AddJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            _jobAdvertisementDal.Add(jobAdvertisement);
            return new Result(true, "İş İlanı Eklendi.");
        }

        public Result DeleteJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            jobAdvertisement.IsActive = false;
            _jobAdvertisementDal.Update(jobAdvertisement);
            return new Result(true, "İş İlanı İnaktif Edildi.");
        }

        public DataResult<List<JobAdvertisement>> GetAllJobAdvertisements()
        {
            return new DataResult<List<JobAdvertisement>>(_jobAdvertisementDal.GetAll(), true, "Aktif/İnaktif Tüm İş İlanları Listelendi");
        }

        public DataResult<JobAdvertisement> GetJobAdvertisementById(int id)
        {
            return new DataResult<JobAdvertisement>(_jobAdvertisementDal.GetById(id), true, "İş ilanı getirildi.");
        }

        public Result UpdateJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            _jobAdvertisementDal.Update(jobAdvertisement);
            return new Result(true, "İş İlanı Güncellendi.");
        }
    }
}
