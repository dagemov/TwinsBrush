using Twins.Shared.Entities;

namespace Twins.Shared.DTOs
{
    public class AddEmployeedUserDTO : User
    {
        public int ServiceId { get; set; }
        public string? CityName { get;set; }
    }
}
