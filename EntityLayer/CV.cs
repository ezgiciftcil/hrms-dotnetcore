using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CV
    {
        [Key]
        public int CVId { get; set; }
        public int UserId { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
    }
}
