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
    public class Carros_DueniosController : Controller
    {
        private readonly CasasdbContext _context;

        public Carros_DueniosController(CasasdbContext context)
        {
            _context = context;
        }

        // GET: Carros_Duenios
        public async Task<IActionResult> Index()
        {
            var casasdbContext = _context.Carros_Duenios.Include(c => c.Duenio);
            return View(await casasdbContext.ToListAsync());
        }

        // GET: Carros_Duenios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carros_Duenios == null)
            {
                return NotFound();
            }

            var carros_duenio = await _context.Carros_Duenios
                .Include(c => c.Duenio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros_duenio == null)
            {
                return NotFound();
            }

            return View(carros_duenio);
        }

        // GET: Carros_Duenios/Create
        public IActionResult Create()
        {
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id");
            return View();
        }

        // POST: Carros_Duenios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre_carro,precio,DuenioId")] Carros_duenio carros_duenio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carros_duenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id", carros_duenio.DuenioId);
            return View(carros_duenio);
        }

        // GET: Carros_Duenios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carros_Duenios == null)
            {
                return NotFound();
            }

            var carros_duenio = await _context.Carros_Duenios.FindAsync(id);
            if (carros_duenio == null)
            {
                return NotFound();
            }
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id", carros_duenio.DuenioId);
            return View(carros_duenio);
        }

        // POST: Carros_Duenios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre_carro,precio,DuenioId")] Carros_duenio carros_duenio)
        {
            if (id != carros_duenio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carros_duenio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Carros_duenioExists(carros_duenio.Id))
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
            ViewData["DuenioId"] = new SelectList(_context.Duenios, "Id", "Id", carros_duenio.DuenioId);
            return View(carros_duenio);
        }

        // GET: Carros_Duenios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carros_Duenios == null)
            {
                return NotFound();
            }

            var carros_duenio = await _context.Carros_Duenios
                .Include(c => c.Duenio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carros_duenio == null)
            {
                return NotFound();
            }

            return View(carros_duenio);
        }

        // POST: Carros_Duenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carros_Duenios == null)
            {
                return Problem("Entity set 'CasasdbContext.Carros_Duenios'  is null.");
            }
            var carros_duenio = await _context.Carros_Duenios.FindAsync(id);
            if (carros_duenio != null)
            {
                _context.Carros_Duenios.Remove(carros_duenio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Carros_duenioExists(int id)
        {
          return (_context.Carros_Duenios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
