using System.ComponentModel.DataAnnotations;

namespace TwinsBrushMVC.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Street> Streets { get; set; }
        public State State { get; set; }
    }
}
