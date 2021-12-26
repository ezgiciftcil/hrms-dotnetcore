using BusinessLayer.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class JobAdvertisementService : IJobAdvertisementService
    {
        private IJobAdvertisementDal _jobAdvertisementDal;
        private ICityDal _cityDal;
        private IEmployerDal _employerDal;
        public JobAdvertisementService(IJobAdvertisementDal jobAdvertisementDal, ICityDal cityDal, IEmployerDal employerDal)
        {
            _jobAdvertisementDal = jobAdvertisementDal;
            _cityDal = cityDal;
            _employerDal = employerDal;
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
