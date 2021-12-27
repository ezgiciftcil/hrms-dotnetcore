using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Education : IEntity
    {
        public int EducationId { get; set; }
        public int ResumeId { get; set; }
        public string UniversityName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string DepartmentName { get; set; }
        public double GPA { get; set; }
    }
}
