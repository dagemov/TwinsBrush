using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twins.Shared.Entities
{
    public class ServicePicture
    {
        public int Id { get; set; }

        public Service Service { get; set; } = null!;

        public int ServiceId { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; } = null!;
    }
}
