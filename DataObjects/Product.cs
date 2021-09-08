using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Product
    {
        public int ID { get; set; }

        public int CatID { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public float? Price { get; set; }

        public string Desp { get; set; }

        public int? Quantity { get; set; }

        public byte[] Image { get; set; }

        public DateTime Created_at { get; set; }

        public int Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        public bool Is_active { get; set; }
    }
}
