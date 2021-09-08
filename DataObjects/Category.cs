using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime Created_at { get; set; }

        public int Created_by { get; set; }

        public DateTime? Updated_at { get; set; }

        public int? Updated_by { get; set; }

        public bool Is_active { get; set; }
    }
}
