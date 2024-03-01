using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Twins.Shared.Entities
{
    public class Day
    {
        public int Id { get; set; }

        public string? DateName { get; set; }
        public string? DateValue { get; set; }
        public string? Note { get; set; }
        public string? Message { get; set; }

        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public DateTime? StartBreak { get; set; }
        public DateTime? EndBreak { get; set; }

        public int WeekWorkedId { get; set; }
        public WeekWorked? WeekWorked { get; set; }
        public TimeSpan? TotalHours => EndDay - StartDay;
        
        public  float? PayByHour { get;set; }

        public DateTime? EditRecord { get; set; }
        public DateTime? CreatedRecord { get; set; }
    }
}
