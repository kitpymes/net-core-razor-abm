using System;
using System.ComponentModel.DataAnnotations;

namespace Permisos.Models
{
    public class Permisos : EntityBase
    {
        [Required(ErrorMessage ="Este campo es requerido.")]
        [Display(Name = "Nombre Empleado")]
        public string NombreEmpleado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Apellido Empleado")]
        public string ApellidoEmpleado { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Fecha Permiso")]
        [DataType(DataType.Date, ErrorMessage ="Ingrese una fecha correcta.")]
        public DateTime FechaPermiso { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Tipo de Permiso")]
        public int TipoPermisoId { get; set; }
        public TipoPermiso TipoPermiso { get; set; }
    }
}
