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
    public class JobTitleService : IJobTitleService
    {
        private IJobTitleDal _jobTitleDal;
        public JobTitleService(IJobTitleDal jobTitleDal)
        {
            _jobTitleDal = jobTitleDal;
        }

        public Result AddJobTitle(JobTitle jobTitle)
        {
            if (jobTitle.TitleName == null)
            {
                return new Result(false, "İş Ünvanı Boş Bırakılamaz.");
            }

            _jobTitleDal.Add(jobTitle);
            return new Result(true, "İş Ünvanı Eklendi." );
        }

        public Result DeleteJobTitle(JobTitle jobTitle)
        {
            _jobTitleDal.Delete(jobTitle);
            return new Result(true, "İş Ünvanı Silindi");
        }

        public DataResult<List<JobTitle>> GetAllJobTitles()
        {
            return new DataResult<List<JobTitle>>(_jobTitleDal.GetAll(), true, "İş Ünvanları Listelendi.");
        }

        public DataResult<JobTitle> GetJobTitleById(int id)
        {
            return new DataResult<JobTitle>(_jobTitleDal.GetById(id), true, "İş Ünvanı Bulundu.");
        }

        public Result UpdateJobTitle(JobTitle jobTitle)
        {
            _jobTitleDal.Update(jobTitle);
            return new Result(true, "İş Ünvanı Güncellendi");
        }
    }
}
