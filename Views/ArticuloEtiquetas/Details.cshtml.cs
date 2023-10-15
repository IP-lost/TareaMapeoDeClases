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
    public class DetailsModel : PageModel
    {
        private readonly TareaMapeoDeClases.Data.TareaMapeoDeClasesContext _context;

        public DetailsModel(TareaMapeoDeClases.Data.TareaMapeoDeClasesContext context)
        {
            _context = context;
        }

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
    }
}
