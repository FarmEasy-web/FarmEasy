using FarmEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmEasy.ViewModel.Prediction
{
    public class PredictionViewModel
    {
        //public City City { get; set; }
        public int CityId { get; set; }
        public List<City> City { get; set; }
        public int SoilTypeId { get; set; }
        public List<SoilType> SoilTypes { get; set; }
    }
}
