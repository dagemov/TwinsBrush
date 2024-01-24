using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public int WeekWorkedId { get; set; }
        public WeekWorked? WeekWorked { get; set; }

        public TimeSpan? TotalHours => EndDay - StartDay;
    }
}
