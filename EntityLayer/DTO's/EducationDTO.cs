using System;

namespace EntityLayer.DTO_s
{
    public class EducationDTO
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
