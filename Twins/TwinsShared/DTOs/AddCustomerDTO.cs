using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twins.Shared.Entities;

namespace Twins.Shared.DTOs
{
    public class AddCustomerDTO : User
    {
        public int ServiceId { get; set; }
        public string? CityName { get; set; }

        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? NoteAddress { get; set; }
    }
}
