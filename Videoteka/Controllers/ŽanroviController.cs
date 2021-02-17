using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Videoteka.Data;
using Videoteka.Models;
using Microsoft.AspNetCore.Authorization;

namespace Videoteka.Controllers
{
    [Authorize]
    public class ŽanroviController : Controller
    {
        private readonly KontekstBaze _context;

        public ŽanroviController(KontekstBaze context)
        {
            _context = context;
        }

        // GET: Žanrovi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Žanr.ToListAsync());
        }

        // GET: Žanrovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var žanr = await _context.Žanr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (žanr == null)
            {
                return NotFound();
            }

            return View(žanr);
        }

        // GET: Žanrovi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Žanrovi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Filmskižanr")] Žanr žanr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(žanr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(žanr);
        }

        // GET: Žanrovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var žanr = await _context.Žanr.FindAsync(id);
            if (žanr == null)
            {
                return NotFound();
            }
            return View(žanr);
        }

        // POST: Žanrovi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Filmskižanr")] Žanr žanr)
        {
            if (id != žanr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(žanr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ŽanrExists(žanr.Id))
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
            return View(žanr);
        }

        // GET: Žanrovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var žanr = await _context.Žanr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (žanr == null)
            {
                return NotFound();
            }

            return View(žanr);
        }

        // POST: Žanrovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var žanr = await _context.Žanr.FindAsync(id);
            _context.Žanr.Remove(žanr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ŽanrExists(int id)
        {
            return _context.Žanr.Any(e => e.Id == id);
        }
    }
}
