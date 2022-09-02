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
    public class TblTreatmentsController : Controller
    {
        private readonly PoultryUpdatedContext _context;

        public TblTreatmentsController(PoultryUpdatedContext context)
        {
            _context = context;
        }

        // GET: TblTreatments
        public async Task<IActionResult> Index()
        {
            var poultryUpdatedContext = _context.TblTreatments.Include(t => t.Disease);
            return View(await poultryUpdatedContext.ToListAsync());
        }

        // GET: TblTreatments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblTreatments == null)
            {
                return NotFound();
            }

            var tblTreatment = await _context.TblTreatments
                .Include(t => t.Disease)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTreatment == null)
            {
                return NotFound();
            }

            return View(tblTreatment);
        }

        // GET: TblTreatments/Create
        public IActionResult Create()
        {
            ViewData["DiseaseId"] = new SelectList(_context.TblDiseases, "Id", "Id");
            return View();
        }

        // POST: TblTreatments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckedBy,Medicine,DiseaseId,Date")] TblTreatment tblTreatment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTreatment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiseaseId"] = new SelectList(_context.TblDiseases, "Id", "Id", tblTreatment.DiseaseId);
            return View(tblTreatment);
        }

        // GET: TblTreatments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblTreatments == null)
            {
                return NotFound();
            }

            var tblTreatment = await _context.TblTreatments.FindAsync(id);
            if (tblTreatment == null)
            {
                return NotFound();
            }
            ViewData["DiseaseId"] = new SelectList(_context.TblDiseases, "Id", "Id", tblTreatment.DiseaseId);
            return View(tblTreatment);
        }

        // POST: TblTreatments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckedBy,Medicine,DiseaseId,Date")] TblTreatment tblTreatment)
        {
            if (id != tblTreatment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTreatment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTreatmentExists(tblTreatment.Id))
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
            ViewData["DiseaseId"] = new SelectList(_context.TblDiseases, "Id", "Id", tblTreatment.DiseaseId);
            return View(tblTreatment);
        }

        // GET: TblTreatments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblTreatments == null)
            {
                return NotFound();
            }

            var tblTreatment = await _context.TblTreatments
                .Include(t => t.Disease)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTreatment == null)
            {
                return NotFound();
            }

            return View(tblTreatment);
        }

        // POST: TblTreatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblTreatments == null)
            {
                return Problem("Entity set 'PoultryUpdatedContext.TblTreatments'  is null.");
            }
            var tblTreatment = await _context.TblTreatments.FindAsync(id);
            if (tblTreatment != null)
            {
                _context.TblTreatments.Remove(tblTreatment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTreatmentExists(int id)
        {
          return (_context.TblTreatments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
