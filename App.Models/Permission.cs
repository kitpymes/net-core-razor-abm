using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Permission : EntityBase
    {
        [Required(ErrorMessage ="Este campo es requerido.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Apellido")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido.")]
        [DataType(DataType.Date, ErrorMessage ="Ingrese una fecha correcta.")]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

                
        public int PermissionTypeId { get; set; }

        public virtual PermissionType PermissionType { get; set; }
    }
}
