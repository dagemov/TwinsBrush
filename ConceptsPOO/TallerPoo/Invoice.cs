using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerPoo
{
    public class Invoice : IPay
    {
        private ICollection<Product> _products = new List<Product>();
        public void AddProduct(Product p)
        {
            
                _products.Add(p);
            
        }
        public decimal ValueToPay()
        {
            decimal pay = 0;
            foreach (Product product in _products)
            {
                pay += product.ValueToPay();
            }
            return pay;
        }
        public override string ToString()
        {
            string cadena = "====================================\n\t Recip  ";
            foreach (Product p in _products)
            {

                cadena += $"\n\tId : {p.Id}\n\t Description : {p.Description} \n\t Price : {p.Price:C2} \n\t Tax : {p.Tax:P2}"
                   ;
            }
            return cadena+$"\n\tPrice : { ValueToPay():C2}";
           // return $"=========================\nInvoice\n\t ";
        }
    }
}
