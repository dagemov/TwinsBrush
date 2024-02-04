using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class PersonWeek
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int WeekWorkedId { get; set; }
        public WeekWorked WeekWorked { get; set; }


    }
}
