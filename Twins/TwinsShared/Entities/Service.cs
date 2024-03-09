using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twins.Shared.Enum;

namespace Twins.Shared.Entities
{
    public class Service
    {
        //TODO: Remeber write DataNotation To show on the modal
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float? PriceService { get; set; }
        public float? Taz { get; set; }
        public float? FinalPrice => PriceService+(PriceService*Taz) == null ?0 : PriceService + (PriceService * Taz);

       

        public ICollection<ServiceUser>? Users { get; set; }
        public int  UserCount => Users == null ? 0 : Users.Count() ;

        public ICollection<ServicePicture>? Pictures { get; set; }
        //public string? MainPictre => Pictures == null ? string.Empty : Pictures.FirstOrDefault()!.Image;

       // public ICollection<WeekWorked>? WeekWorked { get; set; }
       public ICollection<ServiceDays>? ServiceDays { get; set; }
        public ServiceStatusType ServiceStatusType { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set;} = null!;
    }
}
