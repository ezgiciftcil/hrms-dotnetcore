using EntityLayer;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface ISkillDal:IGenericDal<Skill>
    {
        List<Skill> GetUserAllSkills(int resumeId);
    }
}
