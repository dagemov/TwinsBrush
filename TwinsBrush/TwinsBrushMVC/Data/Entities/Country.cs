using System.ComponentModel.DataAnnotations;

namespace TwinsBrushMVC.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="The field {0} must to have maximo {1} characters")]
        [Display(Name="Country Name")]
        public string Name { get; set; }
        ICollection<State> States { get; set; }
        
    }
}
