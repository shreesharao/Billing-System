using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Entities
{
    class OrderEntity
    {
        public int OrderId { get; set; }
        public string InvoiceNo { get; set; }
        public long CustomerPhNumber { get; set; }
        public int Price { get; set; }
        public double CGST{ get; set; }
        public double SGST { get; set; }
        public int MyProperty { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
