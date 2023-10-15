using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TareaMapeoDeClases.Data;
using TareaMapeoDeClases.Models;

namespace TareaMapeoDeClases.Views.ArticuloEtiquetas
{
    public class DeleteModel : PageModel
    {
        private readonly TareaMapeoDeClases.Data.TareaMapeoDeClasesContext _context;

        public DeleteModel(TareaMapeoDeClases.Data.TareaMapeoDeClasesContext context)
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

            var articuloetiqueta = await _context.ArticuloEtiqueta.FirstOrDefaultAsync(m => m.Etiqueta_Id == id);

            if (articuloetiqueta == null)
            {
                return NotFound();
            }
            else 
            {
                ArticuloEtiqueta = articuloetiqueta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ArticuloEtiqueta == null)
            {
                return NotFound();
            }
            var articuloetiqueta = await _context.ArticuloEtiqueta.FindAsync(id);

            if (articuloetiqueta != null)
            {
                ArticuloEtiqueta = articuloetiqueta;
                _context.ArticuloEtiqueta.Remove(ArticuloEtiqueta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
