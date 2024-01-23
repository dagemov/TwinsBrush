using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float? PriceService { get; set; }
        public float? Taz { get; set; }
        public float? FinalPrice => PriceService*Taz == null ?0 : PriceService * Taz;

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set;} = null!;
    }
}
