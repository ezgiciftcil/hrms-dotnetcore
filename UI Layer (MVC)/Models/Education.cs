using System;

namespace UI_Layer__MVC_.Models
{
    public class Education
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
