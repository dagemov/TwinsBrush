using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Twins.Api.Helpers;

namespace Twins.Shared.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Tax Id, Social security , Passaport")]
        [MaxLength(20)]
        [Required(ErrorMessage = "The field {0} Is required")]
        public string Documment { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;


        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "Chose one {0}.")]
        public int CityId { get; set; }
        public City? City { get; set; }      
        public UserType UserType { get; set; }


        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Picture")]
        public string? Photo { get; set; }

    }
}
