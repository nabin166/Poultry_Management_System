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
    public class TblProductionsController : Controller
    {
        private readonly PoultryUpdatedContext _context;

        public TblProductionsController(PoultryUpdatedContext context)
        {
            _context = context;
        }

        // GET: TblProductions
        public async Task<IActionResult> Index()
        {
            var poultryUpdatedContext = _context.TblProductions.Include(t => t.Poultry);
            return View(await poultryUpdatedContext.ToListAsync());
        }

        // GET: TblProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProductions == null)
            {
                return NotFound();
            }

            var tblProduction = await _context.TblProductions
                .Include(t => t.Poultry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProduction == null)
            {
                return NotFound();
            }

            return View(tblProduction);
        }

        // GET: TblProductions/Create
        public IActionResult Create()
        {
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id");
            return View();
        }

        // POST: TblProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EggType,Quantity,PoultryId")] TblProduction tblProduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id", tblProduction.PoultryId);
            return View(tblProduction);
        }

        // GET: TblProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblProductions == null)
            {
                return NotFound();
            }

            var tblProduction = await _context.TblProductions.FindAsync(id);
            if (tblProduction == null)
            {
                return NotFound();
            }
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id", tblProduction.PoultryId);
            return View(tblProduction);
        }

        // POST: TblProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EggType,Quantity,PoultryId")] TblProduction tblProduction)
        {
            if (id != tblProduction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductionExists(tblProduction.Id))
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
            ViewData["PoultryId"] = new SelectList(_context.TblPoultryFarms, "Id", "Id", tblProduction.PoultryId);
            return View(tblProduction);
        }

        // GET: TblProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblProductions == null)
            {
                return NotFound();
            }

            var tblProduction = await _context.TblProductions
                .Include(t => t.Poultry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProduction == null)
            {
                return NotFound();
            }

            return View(tblProduction);
        }

        // POST: TblProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblProductions == null)
            {
                return Problem("Entity set 'PoultryUpdatedContext.TblProductions'  is null.");
            }
            var tblProduction = await _context.TblProductions.FindAsync(id);
            if (tblProduction != null)
            {
                _context.TblProductions.Remove(tblProduction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductionExists(int id)
        {
          return (_context.TblProductions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
