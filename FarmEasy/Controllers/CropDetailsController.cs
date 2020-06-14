using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmEasy.Data;
using FarmEasy.Models;
using FarmEasy.ViewModel.CropDetails;

namespace FarmEasy.Controllers
{
    public class CropDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CropDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CropDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CropDetails.ToListAsync());
        }

        // GET: CropDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropDetails = await _context.CropDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cropDetails == null)
            {
                return NotFound();
            }
            var model = new CreateCropViewModel();
            model.CropDetails = cropDetails;            
            model.SoilTypes= await (from soilType in _context.SoilTypes
                                    join soilTypeMapping in _context.CropSoilMappings on soilType.Id equals soilTypeMapping.SoilId
                                    where soilTypeMapping.CropId==cropDetails.Id
                                    select soilType).ToListAsync();            

            return View(model);
        }

        // GET: CropDetails/Create
        public IActionResult Create()
        {
            var model = new CreateCropViewModel();
            model.SoilTypes = _context.SoilTypes.ToList();
            return View(model);
        }

        // POST: CropDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCropViewModel cropViewModel)
        {
            if (ModelState.IsValid)
            {
                await  _context.CropDetails.AddAsync(cropViewModel.CropDetails);
                await _context.SaveChangesAsync();
                foreach (var sT in cropViewModel.SoilTypeId)
                {
                    await _context.CropSoilMappings.AddAsync(new CropSoilMapping() { CropId = cropViewModel.CropDetails.Id, SoilId = sT });
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CropType = await _context.SoilTypes.ToListAsync();
            return View(cropViewModel);
        }

        // GET: CropDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropDetails = await _context.CropDetails.FindAsync(id);
            if (cropDetails == null)
            {
                return NotFound();
            }
            var model = new CreateCropViewModel();
            model.CropDetails = cropDetails;
            model.SoilTypes = await _context.SoilTypes.ToListAsync();
            model.SoilTypeId = await _context.CropSoilMappings.Where(x => x.CropId == cropDetails.Id).Select(y => y.SoilId).ToArrayAsync();            
            return View(model);
        }

        // POST: CropDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CreateCropViewModel model)
        {            
            if (id != model.CropDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model.CropDetails);
                    await _context.SaveChangesAsync();
                    var cropSoil = await _context.CropSoilMappings.Where(x => x.CropId == model.CropDetails.Id).ToListAsync();
                    _context.CropSoilMappings.RemoveRange(cropSoil);
                    await _context.SaveChangesAsync();
                    foreach(var sT in model.SoilTypeId)
                    {
                       await _context.CropSoilMappings.AddAsync(new CropSoilMapping() { CropId = model.CropDetails.Id, SoilId = sT });
                       await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CropDetailsExists(model.CropDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CropDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropDetails = await _context.CropDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cropDetails == null)
            {
                return NotFound();
            }

            return View(cropDetails);
        }

        // POST: CropDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cropDetails = await _context.CropDetails.FindAsync(id);
            _context.CropDetails.Remove(cropDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CropDetailsExists(int id)
        {
            return _context.CropDetails.Any(e => e.Id == id);
        }
    }
}
