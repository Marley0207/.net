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
    public class Venta_MotosController : Controller
    {
        private readonly CasasdbContext _context;

        public Venta_MotosController(CasasdbContext context)
        {
            _context = context;
        }

        // GET: Venta_Motos
        public async Task<IActionResult> Index()
        {
              return _context.Venta_Motos != null ? 
                          View(await _context.Venta_Motos.ToListAsync()) :
                          Problem("Entity set 'CasasdbContext.Venta_Motos'  is null.");
        }

        // GET: Venta_Motos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta_Motos == null)
            {
                return NotFound();
            }

            var venta_Moto = await _context.Venta_Motos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta_Moto == null)
            {
                return NotFound();
            }

            return View(venta_Moto);
        }

        // GET: Venta_Motos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venta_Motos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Precio,Marca,Descripcion,Photo")] Venta_Moto venta_Moto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta_Moto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venta_Moto);
        }

        // GET: Venta_Motos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venta_Motos == null)
            {
                return NotFound();
            }

            var venta_Moto = await _context.Venta_Motos.FindAsync(id);
            if (venta_Moto == null)
            {
                return NotFound();
            }
            return View(venta_Moto);
        }

        // POST: Venta_Motos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Precio,Marca,Descripcion,Photo")] Venta_Moto venta_Moto)
        {
            if (id != venta_Moto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta_Moto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Venta_MotoExists(venta_Moto.Id))
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
            return View(venta_Moto);
        }

        // GET: Venta_Motos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venta_Motos == null)
            {
                return NotFound();
            }

            var venta_Moto = await _context.Venta_Motos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta_Moto == null)
            {
                return NotFound();
            }

            return View(venta_Moto);
        }

        // POST: Venta_Motos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venta_Motos == null)
            {
                return Problem("Entity set 'CasasdbContext.Venta_Motos'  is null.");
            }
            var venta_Moto = await _context.Venta_Motos.FindAsync(id);
            if (venta_Moto != null)
            {
                _context.Venta_Motos.Remove(venta_Moto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Venta_MotoExists(int id)
        {
          return (_context.Venta_Motos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public IActionResult Imagenes()
    {
        var images = _context.Venta_Motos
            .Where(o => !string.IsNullOrEmpty(o.Photo))
            .ToList();

        return View("Imagenes", images);
    }
    }
} 
