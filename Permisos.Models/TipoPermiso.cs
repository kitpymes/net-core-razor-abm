using System.ComponentModel.DataAnnotations;

namespace Permisos.Models
{
    public class TipoPermiso : EntityBase
    {
        [Required]
        public string Descripcion { get; private set; }
    }
}
