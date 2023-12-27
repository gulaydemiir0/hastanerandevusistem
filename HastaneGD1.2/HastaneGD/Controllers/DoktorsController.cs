using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneGD.Models;

namespace HastaneGD.Controllers
{
    public class DoktorsController : Controller
    {
        private readonly HContext _context;

        public DoktorsController(HContext context)
        {
            _context = context;
        }

        // GET: Doktors
        public async Task<IActionResult> Index()
        {
              return _context.doktors != null ? 
                          View(await _context.doktors.ToListAsync()) :
                          Problem("Entity set 'HContext.doktors'  is null.");
        }

        // GET: Doktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktors
                .FirstOrDefaultAsync(m => m.doktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doktors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("doktorId,doktorName,abdID,polId")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        // GET: Doktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktors.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // POST: Doktors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("doktorId,doktorName,abdID,polId")] Doktor doktor)
        {
            if (id != doktor.doktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.doktorId))
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
            return View(doktor);
        }

        // GET: Doktors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktors
                .FirstOrDefaultAsync(m => m.doktorId == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.doktors == null)
            {
                return Problem("Entity set 'HContext.doktors'  is null.");
            }
            var doktor = await _context.doktors.FindAsync(id);
            if (doktor != null)
            {
                _context.doktors.Remove(doktor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
          return (_context.doktors?.Any(e => e.doktorId == id)).GetValueOrDefault();
        }
    }
}
