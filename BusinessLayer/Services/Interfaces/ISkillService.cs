using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface ISkillService
    {
        Result AddSkill(int ResumeId, string SkillName);
        Result UpdateSkill(int SkillId, string SkillName);
        Result DeleteSkill(int skillId);
        DataResult<List<Skill>> GetAllSkills();
        DataResult<Skill> GetSkillById(int id);
        DataResult<List<Skill>> GetUserAllSkills(int resumeId);
    }
}
