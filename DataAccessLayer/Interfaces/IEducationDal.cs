using EntityLayer;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IEducationDal:IGenericDal<Education>
    {
        List<Education> GetUserAllEducations(int resumeId);
    }
}
