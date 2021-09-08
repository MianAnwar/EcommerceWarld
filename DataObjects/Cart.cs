using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Cart
    {
        public int ID { get; set; }

        public int Customer_id { get; set; }

        public int Product_id { get; set; }

        public int Quantity { get; set; }
    }
}
