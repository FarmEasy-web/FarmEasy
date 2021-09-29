using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmEasy.Models
{
    public class CropDetails
    {
        [Key]
        public int Id { get; set; }
        public float Temperature_Min { get; set; }
        public float Temperature_Max { get; set; }
        public string CropName { get; set; }
    }
}
