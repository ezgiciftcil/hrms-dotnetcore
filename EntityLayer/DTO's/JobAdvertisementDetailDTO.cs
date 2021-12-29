using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO_s
{
    public class JobAdvertisementDetailDTO
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
