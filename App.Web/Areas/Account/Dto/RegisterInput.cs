
using System.ComponentModel.DataAnnotations;

namespace App.Web.Account
{
    public class RegisterInput
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "El correo electrónico ingresado tiene un formato incorrecto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
