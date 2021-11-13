using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class JobAdvertisement:IEntity
    {
        [Key]
        public int JobAdvertisementId { get; set; }
        [Required]
        [MaxLength(300)]
        public string JobDescription { get; set; }

        public int UserId { get; set; }
        public virtual Employer Employer { get; set; }

        public int JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
    }
}
