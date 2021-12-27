using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Skill : IEntity
    {
        public int SkillId { get; set; }
        public int ResumeId { get; set; }
        public string SkillName { get; set; }
    }
}
