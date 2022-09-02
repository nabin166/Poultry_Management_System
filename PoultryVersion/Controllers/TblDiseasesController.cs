using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoultryVersion.Models;

namespace PoultryVersion.Controllers
{
    [Authorize]
    public class TblDiseasesController : Controller
    {
        private readonly PoultryUpdatedContext _context;

        public TblDiseasesController(PoultryUpdatedContext context)
        {
            _context = context;
        }

        // GET: TblDiseases
        public async Task<IActionResult> Index()
        {
            var poultryUpdatedContext = _context.TblDiseases.Include(t => t.Poultry);
            return View(await poultryUpdatedContext.ToListAsync());
        }

        // GET: TblDiseases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblDiseases == null)
            {
                return NotFound();
            }

            var tblDisease = await _context.TblDiseases
                .Include(t => t.Poultry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDisease == null)
            {
                return NotFound();
            }

            return View(tblDisease);
        }

        // GET: TblDiseases/Create
        public IActionResult Create()
        {
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id");
            return View();
        }

        // POST: TblDiseases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiseaseName,EffectiveNumber,Date,NoOfDead,PoultryId")] TblDisease tblDisease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblDisease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id", tblDisease.PoultryId);
            return View(tblDisease);
        }

        // GET: TblDiseases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblDiseases == null)
            {
                return NotFound();
            }

            var tblDisease = await _context.TblDiseases.FindAsync(id);
            if (tblDisease == null)
            {
                return NotFound();
            }
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id", tblDisease.PoultryId);
            return View(tblDisease);
        }

        // POST: TblDiseases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiseaseName,EffectiveNumber,Date,NoOfDead,PoultryId")] TblDisease tblDisease)
        {
            if (id != tblDisease.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDisease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDiseaseExists(tblDisease.Id))
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
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id", tblDisease.PoultryId);
            return View(tblDisease);
        }

        // GET: TblDiseases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblDiseases == null)
            {
                return NotFound();
            }

            var tblDisease = await _context.TblDiseases
                .Include(t => t.Poultry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDisease == null)
            {
                return NotFound();
            }

            return View(tblDisease);
        }

        // POST: TblDiseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblDiseases == null)
            {
                return Problem("Entity set 'PoultryUpdatedContext.TblDiseases'  is null.");
            }
            var tblDisease = await _context.TblDiseases.FindAsync(id);
            if (tblDisease != null)
            {
                _context.TblDiseases.Remove(tblDisease);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDiseaseExists(int id)
        {
          return (_context.TblDiseases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
