using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class ServiceUser
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public User? User { get; set; }  = null!;
        public int ServiceId { get; set; }
        public Service? Service { get; set; } = null!;
        public string? EmployedDocument { get; set; }
        public float TotalHourService { get; set; }
        public float TotalToPay {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? StreetId { get; set; }
        public Street? Street { get; set; }
    }
}
