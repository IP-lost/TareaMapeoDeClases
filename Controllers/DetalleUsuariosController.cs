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
    public class DetalleUsuariosController : Controller
    {
        private readonly TareaMapeoDeClasesContext _context;

        public DetalleUsuariosController(TareaMapeoDeClasesContext context)
        {
            _context = context;
        }

        // GET: DetalleUsuarios
        public async Task<IActionResult> Index()
        {
              return _context.DetalleUsuario != null ? 
                          View(await _context.DetalleUsuario.ToListAsync()) :
                          Problem("Entity set 'TareaMapeoDeClasesContext.DetalleUsuario'  is null.");
        }

        // GET: DetalleUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleUsuario == null)
            {
                return NotFound();
            }

            var detalleUsuario = await _context.DetalleUsuario
                .FirstOrDefaultAsync(m => m.Detalle_Usuario_Id == id);
            if (detalleUsuario == null)
            {
                return NotFound();
            }

            return View(detalleUsuario);
        }

        // GET: DetalleUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Detalle_Usuario_Id,Cedula,Deporte,Mascota")] DetalleUsuario detalleUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleUsuario);
        }

        // GET: DetalleUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleUsuario == null)
            {
                return NotFound();
            }

            var detalleUsuario = await _context.DetalleUsuario.FindAsync(id);
            if (detalleUsuario == null)
            {
                return NotFound();
            }
            return View(detalleUsuario);
        }

        // POST: DetalleUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Detalle_Usuario_Id,Cedula,Deporte,Mascota")] DetalleUsuario detalleUsuario)
        {
            if (id != detalleUsuario.Detalle_Usuario_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleUsuarioExists(detalleUsuario.Detalle_Usuario_Id))
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
            return View(detalleUsuario);
        }

        // GET: DetalleUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleUsuario == null)
            {
                return NotFound();
            }

            var detalleUsuario = await _context.DetalleUsuario
                .FirstOrDefaultAsync(m => m.Detalle_Usuario_Id == id);
            if (detalleUsuario == null)
            {
                return NotFound();
            }

            return View(detalleUsuario);
        }

        // POST: DetalleUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleUsuario == null)
            {
                return Problem("Entity set 'TareaMapeoDeClasesContext.DetalleUsuario'  is null.");
            }
            var detalleUsuario = await _context.DetalleUsuario.FindAsync(id);
            if (detalleUsuario != null)
            {
                _context.DetalleUsuario.Remove(detalleUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleUsuarioExists(int id)
        {
          return (_context.DetalleUsuario?.Any(e => e.Detalle_Usuario_Id == id)).GetValueOrDefault();
        }
    }
}
