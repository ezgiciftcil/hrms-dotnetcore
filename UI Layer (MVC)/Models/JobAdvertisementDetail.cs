using System;

namespace UI_Layer__MVC_.Models
{
    public class JobAdvertisementDetail
    {
        public string CityName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string JobDescription { get; set; }
        public string JobTitle { get; set; }
        public int MaxSalary { get; set; }
        public int MinSalary { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
