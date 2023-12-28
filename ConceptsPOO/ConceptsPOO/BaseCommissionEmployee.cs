using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptsPOO
{
    public class BaseCommissionEmployee :CommissionEmployee
    {
        public decimal Base { get; set; }

        public override decimal GetValueToPay()
        {
            return base.GetValueToPay()+Base;
        }
        public override string ToString()
        {
            return $"{base.ToString()}" +$" Base : {Base:C2}"+$"\n\t Commision Porcentaje : {CommisionPorcentaje:P2}"+$" Sales Value : {Sales}"+
                $"+\n\t Value Total to pay : {$"{GetValueToPay():C2}",15}";
        }
    }
}
