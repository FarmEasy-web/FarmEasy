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
    public class SoilTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoilTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SoilTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoilTypes.ToListAsync());
        }

        // GET: SoilTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soilType = await _context.SoilTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soilType == null)
            {
                return NotFound();
            }

            return View(soilType);
        }

        // GET: SoilTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoilTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SoilName")] SoilType soilType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soilType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soilType);
        }

        // GET: SoilTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soilType = await _context.SoilTypes.FindAsync(id);
            if (soilType == null)
            {
                return NotFound();
            }
            return View(soilType);
        }

        // POST: SoilTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SoilName")] SoilType soilType)
        {
            if (id != soilType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soilType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoilTypeExists(soilType.Id))
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
            return View(soilType);
        }

        // GET: SoilTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soilType = await _context.SoilTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soilType == null)
            {
                return NotFound();
            }

            return View(soilType);
        }

        // POST: SoilTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soilType = await _context.SoilTypes.FindAsync(id);
            _context.SoilTypes.Remove(soilType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoilTypeExists(int id)
        {
            return _context.SoilTypes.Any(e => e.Id == id);
        }
    }
}
