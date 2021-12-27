using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface ISkillService
    {
        Result AddSkill(Skill skill);
        Result UpdateSkill(Skill skill);
        Result DeleteSkill(Skill skill);
        DataResult<List<Skill>> GetAllSkills();
        DataResult<Skill> GetSkillById(int id);
    }
}
