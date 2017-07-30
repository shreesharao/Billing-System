using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.DatabaseHelper
{
    interface IDBhelper
    {
        DataSet ExecuteDataset(string query);
        object ExecuteScalar(string query);
        int ExecuteNonQuery(string query);
        //T ExecuteReader(string query);
    }
}
