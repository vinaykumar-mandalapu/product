using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_api
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
