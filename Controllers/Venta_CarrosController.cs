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
    public class Venta_CarrosController : Controller
    {
        private readonly CasasdbContext _context;

        public Venta_CarrosController(CasasdbContext context)
        {
            _context = context;
        }

        // GET: Venta_Carros
        public async Task<IActionResult> Index()
        {
              return _context.Venta_Carros != null ? 
                          View(await _context.Venta_Carros.ToListAsync()) :
                          Problem("Entity set 'CasasdbContext.Venta_Carros'  is null.");
        }

        // GET: Venta_Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta_Carros == null)
            {
                return NotFound();
            }

            var venta_Carro = await _context.Venta_Carros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta_Carro == null)
            {
                return NotFound();
            }

            return View(venta_Carro);
        }

        // GET: Venta_Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venta_Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Precio,Marca,Descripcion,Photo")] Venta_Carro venta_Carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta_Carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venta_Carro);
        }

        // GET: Venta_Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venta_Carros == null)
            {
                return NotFound();
            }

            var venta_Carro = await _context.Venta_Carros.FindAsync(id);
            if (venta_Carro == null)
            {
                return NotFound();
            }
            return View(venta_Carro);
        }

        // POST: Venta_Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Precio,Marca,Descripcion,Photo")] Venta_Carro venta_Carro)
        {
            if (id != venta_Carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta_Carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Venta_CarroExists(venta_Carro.Id))
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
            return View(venta_Carro);
        }

        // GET: Venta_Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venta_Carros == null)
            {
                return NotFound();
            }

            var venta_Carro = await _context.Venta_Carros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta_Carro == null)
            {
                return NotFound();
            }

            return View(venta_Carro);
        }

        // POST: Venta_Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venta_Carros == null)
            {
                return Problem("Entity set 'CasasdbContext.Venta_Carros'  is null.");
            }
            var venta_Carro = await _context.Venta_Carros.FindAsync(id);
            if (venta_Carro != null)
            {
                _context.Venta_Carros.Remove(venta_Carro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Venta_CarroExists(int id)
        {
          return (_context.Venta_Carros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public IActionResult Ranking()
        {
        var mas_caros= _context.Venta_Carros
            .OrderByDescending(o => o.Precio)
            .ToList();

        return View("Ranking", mas_caros);
        }
        public IActionResult Ranking2()
        {
        var mas_baratos= _context.Venta_Carros
            .OrderBy(o => o.Precio)
            .ToList();

        return View("Ranking2", mas_baratos);
        }
    }
}
