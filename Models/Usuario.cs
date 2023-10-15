using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TareaMapeoDeClases.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [EmailAddress(ErrorMessage = "Ingresa un mail correcto")]
        public string Email { get; set; }
        [Display(Name = "Direccion Usuari")]
        public string Dirreccion { get; set; }
        [NotMapped]
        public int Edad { get; set; }
        [ForeignKey("DetalleUsuario")]



        public int DetalleUsuario_Id { get; set; }



        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
