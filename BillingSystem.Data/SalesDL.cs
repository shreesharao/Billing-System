using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Utility.DatabaseHelper;
using Utility.LogHelper;

namespace BillingSystem.Data
{
    public class SalesDL:BaseDL
    {
        private DatabaseGateway _objDatabaseGateway = null;
        private string _dbType = string.Empty;
        private LogGateway _objLogGateway = null;

        public SalesDL()
        {
            _dbType = base.GetDatabaseTypeFromConfig();
            _objLogGateway = new LogGateway(this.GetType());
        }
        public DataSet GetAllItems()
        {
            DataSet ds = null;
            _objDatabaseGateway = new DatabaseGateway(_dbType);

            try
            {
                var query = "SELECT ItemId,ItemName,Quantity FROM TB_ITEMS";
                ds=_objDatabaseGateway.ExecuteDataset(query);
            }
            catch (Exception ex)
            {
                _objLogGateway.Fatal(ex);
            }
            return ds;
        }

    }
}
