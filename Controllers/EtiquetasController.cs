using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TareaMapeoDeClases.Data;
using TareaMapeoDeClases.Models;

namespace TareaMapeoDeClases.Controllers
{
    public class EtiquetasController : Controller
    {
        private readonly TareaMapeoDeClasesContext _context;

        public EtiquetasController(TareaMapeoDeClasesContext context)
        {
            _context = context;
        }

        // GET: Etiquetas
        public async Task<IActionResult> Index()
        {
              return _context.Etiqueta != null ? 
                          View(await _context.Etiqueta.ToListAsync()) :
                          Problem("Entity set 'TareaMapeoDeClasesContext.Etiqueta'  is null.");
        }

        // GET: Etiquetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etiqueta == null)
            {
                return NotFound();
            }

            var etiqueta = await _context.Etiqueta
                .FirstOrDefaultAsync(m => m.Etiqueta_Id == id);
            if (etiqueta == null)
            {
                return NotFound();
            }

            return View(etiqueta);
        }

        // GET: Etiquetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etiquetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Etiqueta_Id,Titulo,Fecha")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etiqueta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etiqueta);
        }

        // GET: Etiquetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etiqueta == null)
            {
                return NotFound();
            }

            var etiqueta = await _context.Etiqueta.FindAsync(id);
            if (etiqueta == null)
            {
                return NotFound();
            }
            return View(etiqueta);
        }

        // POST: Etiquetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Etiqueta_Id,Titulo,Fecha")] Etiqueta etiqueta)
        {
            if (id != etiqueta.Etiqueta_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etiqueta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtiquetaExists(etiqueta.Etiqueta_Id))
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
            return View(etiqueta);
        }

        // GET: Etiquetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etiqueta == null)
            {
                return NotFound();
            }

            var etiqueta = await _context.Etiqueta
                .FirstOrDefaultAsync(m => m.Etiqueta_Id == id);
            if (etiqueta == null)
            {
                return NotFound();
            }

            return View(etiqueta);
        }

        // POST: Etiquetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etiqueta == null)
            {
                return Problem("Entity set 'TareaMapeoDeClasesContext.Etiqueta'  is null.");
            }
            var etiqueta = await _context.Etiqueta.FindAsync(id);
            if (etiqueta != null)
            {
                _context.Etiqueta.Remove(etiqueta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtiquetaExists(int id)
        {
          return (_context.Etiqueta?.Any(e => e.Etiqueta_Id == id)).GetValueOrDefault();
        }
    }
}
