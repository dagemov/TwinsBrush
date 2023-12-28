using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerPoo
{
    public class VariablePriceProduct : Product
    {
        public string Measurement { get; set; }
        public float Quantity { get; set; }
        public override decimal ValueToPay()
        {
            return (Price*(decimal)Quantity);
        }
        public override string ToString()
        {
            return base.ToString()+ $" Measurement : {Measurement:F2}\n\t Quantity : {Quantity:F2} \n\t Value to pay : {ValueToPay():C2}";
        }
    }
}
