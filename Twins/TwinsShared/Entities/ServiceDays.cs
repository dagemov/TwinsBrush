using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class ServiceDays
    {
        public int Id { get; set; }      
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public int DayId { get; set; }
        public Day? Day { get; set; }
        public ICollection<User>? Emplooyes { get; set; }
        public int EmplooyesCount => Emplooyes == null ? 0 : Emplooyes.Count();
        public  string? DateValue { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
