using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class OrderDetail
    {
        public string Prod_Name { get; set; }

        public int Prod_quantity { get; set; }

        public float? Prod_price { get; set; }
        public float? Net_total { get; set; }

        public DateTime Created_at { get; set; }
    }
}
