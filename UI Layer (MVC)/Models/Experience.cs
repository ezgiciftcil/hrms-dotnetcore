using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer__MVC_.Models
{
    public class Experience
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
