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
    public class VaniController : Controller
    {
        private readonly KontekstBaze _context;

        public VaniController(KontekstBaze context)
        {
            _context = context;
        }

        // GET: Vani
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Vani.ToListAsync());
        }

        // GET: Vani/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vani = await _context.Vani
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vani == null)
            {
                return NotFound();
            }

            return View(vani);
        }

        // GET: Vani/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vani/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Film,Izašao")] Vani vani)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vani);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vani);
        }

        // GET: Vani/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vani = await _context.Vani.FindAsync(id);
            if (vani == null)
            {
                return NotFound();
            }
            return View(vani);
        }

        // POST: Vani/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Film,Izašao")] Vani vani)
        {
            if (id != vani.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vani);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaniExists(vani.Id))
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
            return View(vani);
        }

        // GET: Vani/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vani = await _context.Vani
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vani == null)
            {
                return NotFound();
            }

            return View(vani);
        }

        // POST: Vani/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vani = await _context.Vani.FindAsync(id);
            _context.Vani.Remove(vani);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaniExists(int id)
        {
            return _context.Vani.Any(e => e.Id == id);
        }
    }
}
