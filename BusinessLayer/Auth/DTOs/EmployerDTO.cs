using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Auth.DTOs
{
    public class EmployerDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string ContactNumber { get; set; }
    }
}
