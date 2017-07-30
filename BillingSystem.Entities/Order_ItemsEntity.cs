using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Entities
{
    class Order_ItemsEntity
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public double SoldPrice { get; set; }
        public int SoldQuantity { get; set; }
    }
}
