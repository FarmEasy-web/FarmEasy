using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FarmEasy.Controllers
{
    public class PriceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}