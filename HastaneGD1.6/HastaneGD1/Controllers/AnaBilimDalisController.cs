﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneGD1.Data;
using HastaneGD1.Models;
using Microsoft.AspNetCore.Authorization;

namespace HastaneGD1.Controllers
{
    public class AnaBilimDalisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnaBilimDalisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnaBilimDalis
        public async Task<IActionResult> Index()
        {
              return _context.anaBilimDali != null ? 
                          View(await _context.anaBilimDali.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.anaBilimDali'  is null.");
        }

        // GET: AnaBilimDalis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.anaBilimDali == null)
            {
                return NotFound();
            }

            var anaBilimDali = await _context.anaBilimDali
                .FirstOrDefaultAsync(m => m.abdId == id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }

            return View(anaBilimDali);
        }

        // GET: AnaBilimDalis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnaBilimDalis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("abdId,abdName")] AnaBilimDali anaBilimDali)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anaBilimDali);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anaBilimDali);
        }

        // GET: AnaBilimDalis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.anaBilimDali == null)
            {
                return NotFound();
            }

            var anaBilimDali = await _context.anaBilimDali.FindAsync(id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }
            return View(anaBilimDali);
        }

        // POST: AnaBilimDalis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("abdId,abdName")] AnaBilimDali anaBilimDali)
        {
            if (id != anaBilimDali.abdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anaBilimDali);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaBilimDaliExists(anaBilimDali.abdId))
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
            return View(anaBilimDali);
        }

        // GET: AnaBilimDalis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.anaBilimDali == null)
            {
                return NotFound();
            }

            var anaBilimDali = await _context.anaBilimDali
                .FirstOrDefaultAsync(m => m.abdId == id);
            if (anaBilimDali == null)
            {
                return NotFound();
            }

            return View(anaBilimDali);
        }

        // POST: AnaBilimDalis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.anaBilimDali == null)
            {
                return Problem("Entity set 'ApplicationDbContext.anaBilimDali'  is null.");
            }
            var anaBilimDali = await _context.anaBilimDali.FindAsync(id);
            if (anaBilimDali != null)
            {
                _context.anaBilimDali.Remove(anaBilimDali);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaBilimDaliExists(int id)
        {
          return (_context.anaBilimDali?.Any(e => e.abdId == id)).GetValueOrDefault();
        }
    }
}
