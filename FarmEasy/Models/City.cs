﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmEasy.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; }
    }
}
