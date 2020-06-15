using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmEasy.Data;
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
            var temprature =await PredictionWeather.Predict(city.CityName);
            return View("Index",model);
        }
    }
}