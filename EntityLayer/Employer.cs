using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Employer : User
    {
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(150)]
        public string CompanyWebsite { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
