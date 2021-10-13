using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class User : EntityBase
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
