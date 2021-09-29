using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmEasy.Models
{
    public class SoilType
    {
        [Key]
        public int Id { get; set; }
        public string SoilName { get; set; }
        public string SoilDetails { get; set; }
    }
}
