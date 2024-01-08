using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TwinsBrushMVC.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="The field {0} must to have maximo {1} characters")]
        [Display(Name="Country Name")]
        public string Name { get; set; }
        [JsonIgnore]//1 to n
        public ICollection<State> States { get; set; }

        [Display(Name = "States")]
        public int StatesNumber => States == null ? 0 : States.Count;

    }
}
