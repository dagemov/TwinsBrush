using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twins.Shared.Entities;

namespace Twins.Shared.DTOs
{
    public class AddServiceDay : Service
    {
        public string? DayValue{ get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ServiceId { get; set; }  
    }
}
