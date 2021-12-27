using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillDal _skillDal;
        public SkillService(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }
        public Result AddSkill(Skill skill)
        {
            if (skill.SkillName == null)
            {
                return new Result(false, "Skill can not be empty!");
            }
            _skillDal.Add(skill);
            return new Result(true, "Skill Added.");
        }

        public Result DeleteSkill(Skill skill)
        {
            _skillDal.Delete(skill);
            return new Result(true, "Skill Deleted.");
        }

        public DataResult<List<Skill>> GetAllSkills()
        {
            return new DataResult<List<Skill>>(_skillDal.GetAll(), true);
        }

        public DataResult<Skill> GetSkillById(int id)
        {
            return new DataResult<Skill>(_skillDal.GetById(id), true);
        }

        public Result UpdateSkill(Skill skill)
        {
            _skillDal.Update(skill);
            return new Result(true, "Skill Updated.");
        }
    }
}
