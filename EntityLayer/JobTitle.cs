using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class JobTitle:IEntity
    {
        [Key]
        public int JobTitleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string TitleName { get; set; }
    }
}
