using System;
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
    public class RandevusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Randevus
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Index()
        {

            var dummyv = _context.randevus.Where(x => x.Durum == false).ToList();
            return _context.randevus != null ?
                        View(dummyv) :
                        Problem("Entity set 'ApplicationDbContext.randevus'  is null.");
        }

        // GET: Randevus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }
        [Authorize]
        // GET: Randevus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Randevus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,HastaAdi,HastaSoyadi,Durum")] Randevu randevu)
        {
            
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }
        [Authorize]
        public IActionResult CreateIng()
        {
            return View();
        }

        // POST: Randevus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateIng([Bind("Id,HastaAdi,HastaSoyadi,Durum")] Randevu randevu)
        {

            _context.Add(randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        // GET: Randevus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevus.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            return View(randevu);
        }

        // POST: Randevus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HastaAdi,HastaSoyadi,RandevuTarihi,DoktorAdi,PoliklinikAdi,Durum")] Randevu randevu)
        {
            if (id != randevu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.Id))
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
            return View(randevu);
        }

        // GET: Randevus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.randevus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.randevus'  is null.");
            }
            var randevu = await _context.randevus.FindAsync(id);
            if (randevu != null)
            {
                _context.randevus.Remove(randevu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
            return (_context.randevus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
