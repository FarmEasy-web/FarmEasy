using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmEasy.Data;
using FarmEasy.Models;
using FarmEasy.ViewModel.Prediction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utilities.Helper;

namespace FarmEasy.Controllers
{
    public class PredictionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PredictionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = new PredictionViewModel();
            model.City = await _context.Cities.ToListAsync();
            model.SoilTypes = await _context.SoilTypes.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Prediction(PredictionViewModel model)
        {
            model.City = await _context.Cities.ToListAsync();
            model.SoilTypes = await _context.SoilTypes.ToListAsync();
            var city = await _context.Cities.Where(x => x.Id == model.CityId).FirstOrDefaultAsync();
            var temprature = await PredictionWeather.Predict(city.CityName);
            var pT = Convert.ToDouble(temprature.ForecastedValue[0]);
            var tempInCel= (pT-32)*5/9;
            var crops = await _context.CropDetails.ToListAsync();
            var predictedCrops = new List<CropDetails>();
            foreach (var crop in crops)
            {
                var St = await _context.CropSoilMappings.Where(x => x.SoilId == model.SoilTypeId && x.CropId == crop.Id).FirstOrDefaultAsync();
                if ((tempInCel >= crop.Temperature_Min && tempInCel <= crop.Temperature_Max) && St != null)
                {
                    predictedCrops.Add(crop);
                }
            }
            model.Crops = predictedCrops;
            return View("Index", model);
        }
    }
}