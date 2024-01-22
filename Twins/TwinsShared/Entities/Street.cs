using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class Street
    {
        public int Id { get; set; }
        [Display(Name = "Street Name")]
        [MaxLength(100, ErrorMessage = "The field {0} don't can have more {1} caracters")]
        [Required(ErrorMessage = "The filed {0} is required")]
        public string Name { get; set; } = null!;

        [MaxLength(5, ErrorMessage = "The field {0} don't can have more {1} caracters")]
        [MinLength(5)]
        [Required(ErrorMessage = "The filed {0} is required")]
        public string ZipCode { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public int CityId { get; set; }
        public City? City { get; set; } = null!;

       
    }
}
