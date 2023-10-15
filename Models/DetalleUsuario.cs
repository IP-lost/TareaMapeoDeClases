using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TareaMapeoDeClases.Models
{
    public class DetalleUsuario
    {
        [Key]
        public int Detalle_Usuario_Id { get; set; }
        [Required]
        public string Cedula { get; set; }

        public string Deporte { get; set; }

        public string Mascota { get; set; }

        public Usuario Usuario    { get; set; }
    }
}
