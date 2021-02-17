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
    public class FilmoviController : Controller
    {
        private readonly KontekstBaze _context;

        public FilmoviController(KontekstBaze context)
        {
            _context = context;
        }

        // GET: Filmovi
        public async Task<IActionResult> Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                //1. način linq
                var filmovi = from film in _context.Film
                              select film;
                //2. način linq
                filmovi = filmovi.Where(film => film.film.Contains(search));
                return View(filmovi.ToList());
            }

            var kontekstBaze = _context.Film.Include(f => f.Žanr);
            return View(await kontekstBaze.ToListAsync());
        }

        // GET: Filmovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.Žanr)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Filmovi/Create
        public IActionResult Create()
        {
            ViewData["ŽanrId"] = new SelectList(_context.Žanr, "Id", "Filmskižanr");
            return View();
        }

        // POST: Filmovi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,film,Redatelj,Jezik,Opis,ŽanrId")] Film filmovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ŽanrId"] = new SelectList(_context.Žanr, "Id", "Filmskižanr", filmovi.ŽanrId);
            return View(filmovi);
        }

        // GET: Filmovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["ŽanrId"] = new SelectList(_context.Žanr, "Id", "Filmskižanr", film.ŽanrId);
            return View(film);
        }

        // POST: Filmovi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,film,Redatelj,Jezik,Opis,ŽanrId")] Film filmovi)
        {
            if (id != filmovi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(filmovi.Id))
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
            ViewData["ŽanrId"] = new SelectList(_context.Žanr, "Id", "Filmskižanr", filmovi.ŽanrId);
            return View(filmovi);
        }

        // GET: Filmovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.Žanr)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Filmovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.Id == id);
        }
    }
}
