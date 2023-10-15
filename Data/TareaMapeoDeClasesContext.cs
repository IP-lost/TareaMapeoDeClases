using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TareaMapeoDeClases.Models;

namespace TareaMapeoDeClases.Data
{
    public class TareaMapeoDeClasesContext : DbContext
    {
        public TareaMapeoDeClasesContext (DbContextOptions<TareaMapeoDeClasesContext> options)
            : base(options)
        {
        }

        public DbSet<TareaMapeoDeClases.Models.Articulo> Articulo { get; set; } = default!;

        public DbSet<TareaMapeoDeClases.Models.Categoria>? Categoria { get; set; }

        public DbSet<TareaMapeoDeClases.Models.DetalleUsuario>? DetalleUsuario { get; set; }

        public DbSet<TareaMapeoDeClases.Models.Etiqueta>? Etiqueta { get; set; }

        public DbSet<TareaMapeoDeClases.Models.Usuario>? Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.Etiqueta_Id, ae.Articulo_Id });
        }


        public DbSet<TareaMapeoDeClases.Models.ArticuloEtiqueta>? ArticuloEtiqueta { get; set; }

    }
}
