using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class WeekWorked
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        [JsonIgnore]
        public DateTime? Created { get; set; }
        [JsonIgnore]
        public DateTime? Updated { get; set; } = null!;

        //cuando tengamos usiario y semana , en la tabla userwekk se coloca total de horas de la semana + el pago total
    }
}
