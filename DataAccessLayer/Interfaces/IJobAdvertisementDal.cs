using EntityLayer;
using EntityLayer.DTO_s;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IJobAdvertisementDal:IGenericDal<JobAdvertisement>
    {
        List<JobAdvertisementDTO> GetAllActiveJobAdvertisements();
    }
}
