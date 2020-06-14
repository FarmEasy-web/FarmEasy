using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmEasy.Data;
using FarmEasy.Models;

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

            return View(cropDetails);
        }

        // GET: CropDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CropDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperature_Min,Temperature_Max,CropName")] CropDetails cropDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cropDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cropDetails);
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
            return View(cropDetails);
        }

        // POST: CropDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperature_Min,Temperature_Max,CropName")] CropDetails cropDetails)
        {
            if (id != cropDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cropDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CropDetailsExists(cropDetails.Id))
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
            return View(cropDetails);
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
