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
    public class DueniosController : Controller
    {
        private readonly CasasdbContext _context;

        public DueniosController(CasasdbContext context)
        {
            _context = context;
        }

        // GET: Duenios
        public async Task<IActionResult> Index()
        {
              return _context.Duenios != null ? 
                          View(await _context.Duenios.ToListAsync()) :
                          Problem("Entity set 'CasasdbContext.Duenios'  is null.");
        }

        // GET: Duenios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Duenios == null)
            {
                return NotFound();
            }

            var duenio = await _context.Duenios
                .Include(u => u.Casas_Duenios)
                .Include(u => u.Carros_Duenios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duenio == null)
            {
                return NotFound();
            }

            return View(duenio);
        }

        // GET: Duenios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duenios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Edad,Nombre,Correo")] Duenio duenio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duenio);
        }

        // GET: Duenios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Duenios == null)
            {
                return NotFound();
            }

            var duenio = await _context.Duenios.FindAsync(id);
            if (duenio == null)
            {
                return NotFound();
            }
            return View(duenio);
        }

        // POST: Duenios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Edad,Nombre,Correo")] Duenio duenio)
        {
            if (id != duenio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duenio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenioExists(duenio.Id))
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
            return View(duenio);
        }

        // GET: Duenios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Duenios == null)
            {
                return NotFound();
            }

            var duenio = await _context.Duenios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duenio == null)
            {
                return NotFound();
            }

            return View(duenio);
        }

        // POST: Duenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Duenios == null)
            {
                return Problem("Entity set 'CasasdbContext.Duenios'  is null.");
            }
            var duenio = await _context.Duenios.FindAsync(id);
            if (duenio != null)
            {
                _context.Duenios.Remove(duenio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenioExists(int id)
        {
          return (_context.Duenios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
