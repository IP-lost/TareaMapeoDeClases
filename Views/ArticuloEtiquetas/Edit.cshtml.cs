using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TareaMapeoDeClases.Data;
using TareaMapeoDeClases.Models;

namespace TareaMapeoDeClases.Views.ArticuloEtiquetas
{
    public class EditModel : PageModel
    {
        private readonly TareaMapeoDeClases.Data.TareaMapeoDeClasesContext _context;

        public EditModel(TareaMapeoDeClases.Data.TareaMapeoDeClasesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArticuloEtiqueta ArticuloEtiqueta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ArticuloEtiqueta == null)
            {
                return NotFound();
            }

            var articuloetiqueta =  await _context.ArticuloEtiqueta.FirstOrDefaultAsync(m => m.Etiqueta_Id == id);
            if (articuloetiqueta == null)
            {
                return NotFound();
            }
            ArticuloEtiqueta = articuloetiqueta;
           ViewData["Articulo_Id"] = new SelectList(_context.Articulo, "Articulo_Id", "Descripcion");
           ViewData["Etiqueta_Id"] = new SelectList(_context.Etiqueta, "Etiqueta_Id", "Etiqueta_Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArticuloEtiqueta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloEtiquetaExists(ArticuloEtiqueta.Etiqueta_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticuloEtiquetaExists(int id)
        {
          return (_context.ArticuloEtiqueta?.Any(e => e.Etiqueta_Id == id)).GetValueOrDefault();
        }
    }
}
