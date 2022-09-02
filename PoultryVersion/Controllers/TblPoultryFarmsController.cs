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
    public class TblPoultryFarmsController : Controller
    {
        private readonly PoultryUpdatedContext _context;

        public TblPoultryFarmsController(PoultryUpdatedContext context)
        {
            _context = context;
        }

        // GET: TblPoultryFarms
        public async Task<IActionResult> Index()
        {
            var poultryUpdatedContext = _context.TblPoultryFarms.Include(t => t.User);
            return View(await poultryUpdatedContext.ToListAsync());
        }

        // GET: TblPoultryFarms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblPoultryFarms == null)
            {
                return NotFound();
            }

            var tblPoultryFarm = await _context.TblPoultryFarms
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoultryFarm == null)
            {
                return NotFound();
            }

            return View(tblPoultryFarm);
        }

        // GET: TblPoultryFarms/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.TblUsers, "Id", "Id");
            return View();
        }

        // POST: TblPoultryFarms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,NoOfHens,UserId")] TblPoultryFarm tblPoultryFarm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPoultryFarm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.TblUsers, "Id", "Id", tblPoultryFarm.UserId);
            return View(tblPoultryFarm);
        }

        // GET: TblPoultryFarms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblPoultryFarms == null)
            {
                return NotFound();
            }

            var tblPoultryFarm = await _context.TblPoultryFarms.FindAsync(id);
            if (tblPoultryFarm == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.TblUsers, "Id", "Id", tblPoultryFarm.UserId);
            return View(tblPoultryFarm);
        }

        // POST: TblPoultryFarms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,NoOfHens,UserId")] TblPoultryFarm tblPoultryFarm)
        {
            if (id != tblPoultryFarm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPoultryFarm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoultryFarmExists(tblPoultryFarm.Id))
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
            ViewData["UserId"] = new SelectList(_context.TblUsers, "Id", "Id", tblPoultryFarm.UserId);
            return View(tblPoultryFarm);
        }

        // GET: TblPoultryFarms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblPoultryFarms == null)
            {
                return NotFound();
            }

            var tblPoultryFarm = await _context.TblPoultryFarms
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoultryFarm == null)
            {
                return NotFound();
            }

            return View(tblPoultryFarm);
        }

        // POST: TblPoultryFarms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblPoultryFarms == null)
            {
                return Problem("Entity set 'PoultryUpdatedContext.TblPoultryFarms'  is null.");
            }
            var tblPoultryFarm = await _context.TblPoultryFarms.FindAsync(id);
            if (tblPoultryFarm != null)
            {
                _context.TblPoultryFarms.Remove(tblPoultryFarm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoultryFarmExists(int id)
        {
          return (_context.TblPoultryFarms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
