using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class MyOrders
    {
        public int OrderID { get; set; }

        public float? TotalAmount { get; set; }

        public bool Status { get; set; }
        public DateTime Created_at { get; set; }
        public int OrderedItemsCount { get; set; }

    }
}
