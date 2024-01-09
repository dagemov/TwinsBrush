using System.ComponentModel.DataAnnotations;

namespace Twins.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "The field {0} don't can have more {1} caracters")]
        [Required(ErrorMessage = "The filed {0} is required")]
        [Display(Name = "Country Name")]
        public string Name { get; set; } = null!;
    }
}
