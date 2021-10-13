
using System.ComponentModel.DataAnnotations;

namespace App.Web.Account
{
    public class LoginInput
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "El correo electrónico ingresado tiene un formato incorrecto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
