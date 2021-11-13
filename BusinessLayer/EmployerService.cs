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
    public class EmployerService:IEmployerService
    {
        private IEmployerDal _employerDal;
        public EmployerService(IEmployerDal employerDal)
        {
            _employerDal = employerDal;
        }

        public Result AddEmployer(Employer employer)
        {
            if(employer.CompanyName==null || employer.CompanyName.Length < 2)
            {
                return new Result(false, "Şirket adı boş bırakılamaz!");
            }
            if (employer.CompanyWebsite == null)
            {
                return new Result(false, "Web site kısmını boş bırakamazsınız!");
            }
            if(employer.Email == null) //daha önce kullanulmış mı diye de bak 
            {
                return new Result(false, "Email kısmını boş bırakamasınız!");
            }
            if(employer.Password.Length >= 8 && employer.Password.Length <= 12)
            {
                return new Result(false, "Gireceğiniz şifre en az 8, en fazla 12 karakterli olmalıdır!");
            }
            if(!(employer.PhoneNumber.Length!=10 || employer.PhoneNumber.Length != 12))
            {
                return new Result(false, "Şirketinize dair sabit hat veya telefon numarası girmek zorundasınız!");
            }
            else
            {
                _employerDal.Add(employer);
                return new Result(true, "İş yerinizin üyeliği açıldı");
            }

        }

        public Result DeleteEmployer(Employer employer)
        {
            _employerDal.Delete(employer);
            return new Result(true, "Şirket üyeliğiniz silindi.");
        }

        public DataResult<List<Employer>> GetAllEmployers()
        {
            return new DataResult<List<Employer>>(_employerDal.GetAll(), true, "İşveren Üyelikler Sıralanıyor");
        }

        public DataResult<Employer> GetEmployerById(int id)
        {
            return new DataResult<Employer>(_employerDal.GetById(id), true, "İşveren bulundu");
        }

        public Result UpdateEmployer(Employer employer)
        {
            _employerDal.Update(employer);
            return new Result(true, "İşveren bilgileri güncellendi.");
        }
    }
}
