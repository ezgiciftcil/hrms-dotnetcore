﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        [MaxLength(25)]
        public string CityName { get; set; }
        public ICollection<JobAdvertisement> JobAdvertisements;
    }
}