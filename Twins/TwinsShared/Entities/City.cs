using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "City Name")]
        [MaxLength(100, ErrorMessage = "The field {0} don't can have more {1} caracters")]
        [Required(ErrorMessage = "The filed {0} is required")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }
        public State? State { get; set; }
        public ICollection<Street>? Streets { get; set; }
        public int StreetsNumber => Streets == null ? 0 : Streets.Count;
    }
}
