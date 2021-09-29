using FarmEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmEasy.ViewModel.CropDetails
{
    public class CreateCropViewModel
    {
        public FarmEasy.Models.CropDetails CropDetails { get; set; }
        public int[] SoilTypeId { get; set; }
        public List<SoilType> SoilTypes { get; set; }
        public bool ForEdit { get; set; }
    }
}
