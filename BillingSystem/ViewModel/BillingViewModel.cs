using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BillingSystem.Data;

namespace BillingSystem.ViewModel
{

    class BillingViewModel
    {
        private SalesDL _objSalesDL = null;

        public int dataSheet_SN { get; set; }
        public int dataSheet_ID { get; set; }
        public string dataSheet_NAME { get; set; }
        public double dataSheet_MRP { get; set; }
        public string dataSheet_Quantity { get; set; }
        public double dataSheet_Price { get; set; }
        public BillingViewModel()
        {
            dataSheet_Price = 0;
        }

        public List<BillingViewModel> GetAllItems()
        {
            List<BillingViewModel> lst = new List<BillingViewModel>();
            _objSalesDL = new SalesDL();

            DataSet ds = _objSalesDL.GetAllItems();

            foreach (dynamic item in ds.Tables[0].Rows)
            {
                var obj = new BillingViewModel();
                obj.dataSheet_ID = Convert.ToInt32(item["ItemId"]);
                obj.dataSheet_NAME = item["ItemName"].ToString();
                obj.dataSheet_Quantity = item["Quantity"].ToString();
                lst.Add(obj);
            }

            return lst;

        }
    }
}
