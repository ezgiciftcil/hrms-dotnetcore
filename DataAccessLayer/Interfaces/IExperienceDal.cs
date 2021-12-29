using EntityLayer;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IExperienceDal:IGenericDal<Experience>
    {
        List<Experience> GetUserAllExperiences(int resumeId);
    }
}
