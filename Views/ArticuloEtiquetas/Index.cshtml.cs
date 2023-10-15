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
    public class IndexModel : PageModel
    {
        private readonly TareaMapeoDeClases.Data.TareaMapeoDeClasesContext _context;

        public IndexModel(TareaMapeoDeClases.Data.TareaMapeoDeClasesContext context)
        {
            _context = context;
        }

        public IList<ArticuloEtiqueta> ArticuloEtiqueta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ArticuloEtiqueta != null)
            {
                ArticuloEtiqueta = await _context.ArticuloEtiqueta
                .Include(a => a.Articulo)
                .Include(a => a.Etiqueta).ToListAsync();
            }
        }
    }
}
