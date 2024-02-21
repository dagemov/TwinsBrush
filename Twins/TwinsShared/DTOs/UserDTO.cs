using System.ComponentModel.DataAnnotations;
using Twins.Shared.Entities;

namespace Twins.Shared.DTOs
{
    public class UserDTO : User
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} need have to betwen  {2} y {1} caracters.")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} need have to betwen  {2} y {1} caracters.")]
        [Compare("Password", ErrorMessage = "The password and confirm password don't macth")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
