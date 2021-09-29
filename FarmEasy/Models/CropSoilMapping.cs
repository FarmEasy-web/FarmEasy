using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmEasy.Models
{
    public class CropSoilMapping
    {
        [Key]
        public int Id { get; set; }
        public int CropId { get; set; }
        public int SoilId { get; set; }
    }
}
