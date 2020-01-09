using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arkitekten.Models
{
    public class OrderedProduct
    {
        public int OrderedProductId { get; set; }
        public int ProjectId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }

        //Amount is set to string to be able to specify desired amount, e.g. 10kg or 10pcs
        public string Amount { get; set; }
        public DateTime OrderPlaced { get; set; }


    }
}
