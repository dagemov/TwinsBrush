using System.ComponentModel.DataAnnotations;

namespace TwinsBrushMVC.Data.Entities
{
    public class State
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public Country Country { get; set; }
        [Display(Name = "Cities")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
