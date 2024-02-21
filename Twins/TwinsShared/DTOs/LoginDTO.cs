using System.ComponentModel.DataAnnotations;

namespace Twins.Shared.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "You have to input an valid email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [MinLength(6, ErrorMessage = "The field {0} Have to min {1} caracters.")]
        public string Password { get; set; } = null!;

    }
}
