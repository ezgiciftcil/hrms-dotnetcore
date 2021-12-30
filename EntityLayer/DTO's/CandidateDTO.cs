using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO_s
{
    public class CandidateDTO
    {
        public int JobSeekerId { get; set; }
        public int JobAdvertisementId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int ResumeId { get; set; }
        public string Email { get; set; }

    }
}
