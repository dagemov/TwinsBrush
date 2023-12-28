using System.ComponentModel.DataAnnotations;

namespace TwinsBrushMVC.Data.Entities
{
    public class Street
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public City City { get; set; }
    }
}
