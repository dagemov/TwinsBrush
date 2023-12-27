using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptsPOO
{
    public class CommissionEmployee : Employee
    {
        public float CommisionPorcentaje { get; set; }
        public decimal Sales { get; set; }
        public override decimal GetValueToPay()
        {
            return (decimal)(CommisionPorcentaje)*Sales;
        }
        public override string ToString()
        {
            return $"{base.ToString()} +\n\t  Commision To pay  : {GetValueToPay():C2}" +
                $"\n\t Commision Porcentaje : {CommisionPorcentaje:P2} " +
                $"\n\t Sales : {Sales :C2}";
        }
    }
}
