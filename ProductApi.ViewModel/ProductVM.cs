    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.ViewModel
{
    public class ProductVM
    {
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Name { get; set; }
    }
}
