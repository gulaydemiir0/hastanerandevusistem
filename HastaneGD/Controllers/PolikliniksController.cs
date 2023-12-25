﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneGD.Models;

namespace HastaneGD.Controllers
{
    public class PolikliniksController : Controller
    {
        private readonly HContext _context;

        public PolikliniksController(HContext context)
        {
            _context = context;
        }

        // GET: Polikliniks
        public async Task<IActionResult> Index()
        {
            return _context.polikliniks != null ?
                        View(await _context.polikliniks.ToListAsync()) :
                        Problem("Entity set 'HContext.polikliniks'  is null.");
        }

        // GET: Polikliniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.polikliniks
                .FirstOrDefaultAsync(m => m.polId == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // GET: Polikliniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polikliniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("polId,polName")] Poliklinik poliklinik)
        {

            _context.Add(poliklinik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Polikliniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.polikliniks.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            return View(poliklinik);
        }

        // POST: Polikliniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("polId,polName")] Poliklinik poliklinik)
        {
            if (id != poliklinik.polId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poliklinik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliklinikExists(poliklinik.polId))
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
            return View(poliklinik);
        }

        // GET: Polikliniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.polikliniks
                .FirstOrDefaultAsync(m => m.polId == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // POST: Polikliniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.polikliniks == null)
            {
                return Problem("Entity set 'HContext.polikliniks'  is null.");
            }
            var poliklinik = await _context.polikliniks.FindAsync(id);
            if (poliklinik != null)
            {
                _context.polikliniks.Remove(poliklinik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliklinikExists(int id)
        {
            return (_context.polikliniks?.Any(e => e.polId == id)).GetValueOrDefault();
        }
    }
}
