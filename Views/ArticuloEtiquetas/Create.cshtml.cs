using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TareaMapeoDeClases.Data;
using TareaMapeoDeClases.Models;

namespace TareaMapeoDeClases.Views.ArticuloEtiquetas
{
    public class CreateModel : PageModel
    {
        private readonly TareaMapeoDeClases.Data.TareaMapeoDeClasesContext _context;

        public CreateModel(TareaMapeoDeClases.Data.TareaMapeoDeClasesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Articulo_Id"] = new SelectList(_context.Articulo, "Articulo_Id", "Descripcion");
        ViewData["Etiqueta_Id"] = new SelectList(_context.Etiqueta, "Etiqueta_Id", "Etiqueta_Id");
            return Page();
        }

        [BindProperty]
        public ArticuloEtiqueta ArticuloEtiqueta { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ArticuloEtiqueta == null || ArticuloEtiqueta == null)
            {
                return Page();
            }

            _context.ArticuloEtiqueta.Add(ArticuloEtiqueta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
