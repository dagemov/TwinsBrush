﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name = "State Name")]
        [MaxLength(100, ErrorMessage = "The field {0} don't can have more {1} caracters")]
        [Required(ErrorMessage = "The filed {0} is required")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<City>? Cities { get; set; }
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
