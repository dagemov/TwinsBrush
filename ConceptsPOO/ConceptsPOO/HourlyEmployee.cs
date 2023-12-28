using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptsPOO
{
    public class HourlyEmployee : Employee
    {
        public int Hours { get; set; }
        public decimal HourValue {  get; set; }
        public override decimal GetValueToPay()
        {
            return Hours*HourValue;
        }
        public override string ToString()
        {
            return $"{base.ToString()}+\n\t Value to pay : {$"{GetValueToPay():C2}",15}";
        }
    }
}
