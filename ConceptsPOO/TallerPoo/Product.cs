using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerPoo
{
    public abstract class Product : IPay
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Tax { get; set; }
        public abstract decimal ValueToPay();

        public override string ToString()
        {
            return $"Product : {Id} \n\t" +
                $"Description {Description} \n\t Price : {Price:C2}\n\t Tax : {Tax:P2}\n\t";
        }

    }
}
