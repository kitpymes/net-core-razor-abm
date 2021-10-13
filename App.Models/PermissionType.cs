using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class PermissionType : EntityBase
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Descripcion { get; private set; }
    }
}
