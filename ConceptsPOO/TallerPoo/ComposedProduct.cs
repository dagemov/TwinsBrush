using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerPoo
{
    public class ComposedProduct : Product
    {
        public float Discount { get; set; }
        public ICollection<Product> Products { get; set; }
        public override decimal ValueToPay()
        {
            decimal pay = 0;
            foreach (Product p in Products)
            {
                 pay = p.Price-(p.Price * (decimal)Discount);
            }
            return pay;
        }
        public override string ToString()
        {
            string cadena = $"Id : {Id} \n\t Description : {Description} \n\t Discount{Discount}\n\t Products : ";
            foreach (Product p in Products)
            {
                
                 cadena += $"\n\t Id : {p.Id}\n\t Description : {p.Description} \n\t Price : {p.Price:C2} \n\t Tax : {p.Tax:P2}\n\t"
                    +$"Discount {Discount:P2} \n\t ";
                    //Console.WriteLine("Products : "+Products);
            }
            return cadena;
        }
    }
}
