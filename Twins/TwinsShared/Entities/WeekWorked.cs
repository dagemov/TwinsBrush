using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [MaxLength(7,ErrorMessage ="The week only must have maximum 7 days")]
        public ICollection<Day>? Days { get; set; }
        public int DaysNumber => Days == null ? 0 : Days.Count;

        public int ServiceId { get; set; }
        public Service? Service { get; set; }
       
       // public List<Day>? DaysList { get; set;} = new List<Day>();
    }
}
