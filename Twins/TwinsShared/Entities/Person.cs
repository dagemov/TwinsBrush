using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class Person 
    {
        public int Id { get; set; }
        [MaxLength(100,ErrorMessage ="The field {0} only must have Max {1}  chars")]
        public string Name { get; set; } = null!;
        [MaxLength(100, ErrorMessage = "The field {0} only must have Max {1}  chars")]
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<PersonWeek>? Weeks { get; set; }

    }
}
