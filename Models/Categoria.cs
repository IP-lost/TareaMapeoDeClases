using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TareaMapeoDeClases.Models
{
    public class Categoria
    {
        [Key] 
        public int Categoria_Id { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        public string Nombre { get; set; }


        public List<Articulo> Articulo { get; set; }



    }
}
