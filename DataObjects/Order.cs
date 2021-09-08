using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Order
    {
        public int ID { get; set; }

        public int Cust_id { get; set; }

        public float? Total_amount { get; set; }

        public bool? Status { get; set; }

        public DateTime Created_at { get; set; }

        public int Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        public bool Is_active { get; set; }
    }
}
