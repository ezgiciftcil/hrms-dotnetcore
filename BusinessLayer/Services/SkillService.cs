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
        public Result AddSkill(int ResumeId,string SkillName)
        {
            if (SkillName == null)
            {
                return new Result(false, "Skill can not be empty!");
            }
            var newSkill = new Skill
            {
                ResumeId = ResumeId,
                SkillName = SkillName
            };
            _skillDal.Add(newSkill);
            return new Result(true, "Skill Added.");
        }

        public Result DeleteSkill(int skillId)
        {
            var deletedSkill = new Skill
            {
                SkillId = skillId,
                
        };
            _skillDal.Delete(deletedSkill);
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

        public DataResult<List<Skill>> GetUserAllSkills(int JobSeekerId)
        {
            return new DataResult<List<Skill>>(_skillDal.GetUserAllSkills(JobSeekerId), true);
        }

        public Result UpdateSkill(int SkillId,string SkillName)
        {
            var updatedSkill = new Skill
            {
                SkillId = SkillId,
                SkillName = SkillName
            };
            _skillDal.Update(updatedSkill);
            return new Result(true, "Skill Updated.");
        }
    }
}
