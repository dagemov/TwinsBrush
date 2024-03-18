using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class ServicesCustomer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumberAgency { get; set; }
        
        public string? CustomerDocument { get; set; }
        public float TotalHourService { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string UserId { get; set; } = null!;
        public User? User { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service? Service { get; set; } = null!;
    }
}
