using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test1.Models;

namespace Test1.Controllers
{
    public class Casas_DueniosController : Controller
    {
        private readonly CasasdbContext _context;

        public Casas_DueniosController(CasasdbContext context)
        {
            _context = context;
        }

        // GET: Casas_Duenios
        public async Task<IActionResult> Index()
        {
            var casasdbContext = _context.Casas_Duenios.Include(c => c.Duenio);
            return View(await casasdbContext.ToListAsync());
        }

        // GET: Casas_Duenios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Casas_Duenios == null)
            {
                return NotFound();
            }

            var casas_duenio = await _context.Casas_Duenios
                .Include(c => c.Duenio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casas_duenio == null)
            {
                return NotFound();
            }

            return View(casas_duenio);
        }

        // GET: Casas_Duenios/Create
        public IActionResult Create()
        {
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id");
            return View();
        }

        // POST: Casas_Duenios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre_casa,precio,DuenioId")] Casas_duenio casas_duenio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casas_duenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id", casas_duenio.DuenioId);
            return View(casas_duenio);
        }

        // GET: Casas_Duenios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Casas_Duenios == null)
            {
                return NotFound();
            }

            var casas_duenio = await _context.Casas_Duenios.FindAsync(id);
            if (casas_duenio == null)
            {
                return NotFound();
            }
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id", casas_duenio.DuenioId);
            return View(casas_duenio);
        }

        // POST: Casas_Duenios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre_casa,precio,DuenioId")] Casas_duenio casas_duenio)
        {
            if (id != casas_duenio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casas_duenio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Casas_duenioExists(casas_duenio.Id))
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
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id", casas_duenio.DuenioId);
            return View(casas_duenio);
        }

        // GET: Casas_Duenios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Casas_Duenios == null)
            {
                return NotFound();
            }

            var casas_duenio = await _context.Casas_Duenios
                .Include(c => c.Duenio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casas_duenio == null)
            {
                return NotFound();
            }

            return View(casas_duenio);
        }

        // POST: Casas_Duenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Casas_Duenios == null)
            {
                return Problem("Entity set 'CasasdbContext.Casas_Duenios'  is null.");
            }
            var casas_duenio = await _context.Casas_Duenios.FindAsync(id);
            if (casas_duenio != null)
            {
                _context.Casas_Duenios.Remove(casas_duenio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Casas_duenioExists(int id)
        {
          return (_context.Casas_Duenios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
