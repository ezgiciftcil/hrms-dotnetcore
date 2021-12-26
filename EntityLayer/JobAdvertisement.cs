using System;

namespace EntityLayer
{
    public class JobAdvertisement : IEntity
    {
        public int JobAdvertisementId { get; set; }
        public int EmployerId { get; set; }
        public int CityId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }

    }
}
