using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class TipoPermiso : EntityBase
    {
        [Required]
        public string Descripcion { get; private set; }
    }
}
