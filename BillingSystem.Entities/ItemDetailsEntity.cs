using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Entities
{
    class ItemDetailsEntity
    {
        public int ItemId { get; set; }
        public int PurchasedQuanity { get; set; }
        public double PurchasedPrice { get; set; }
        public string PurchasedFrom { get; set; }
        public DateTime PurchasedDate { get; set; }

    }
}
