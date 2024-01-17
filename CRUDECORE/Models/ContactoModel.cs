using System.ComponentModel.DataAnnotations;

namespace CRUDECORE.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Correo { get; set; }
        
    }
}
