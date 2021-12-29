using System;

namespace EntityLayer.DTO_s
{
    public class ExperienceDTO
    {
        public int ExperienceId { get; set; }
        public int ResumeId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string JobDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

