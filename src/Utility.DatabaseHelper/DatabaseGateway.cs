using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using Utility.LogHelper;

namespace Utility.DatabaseHelper
{
    public class DatabaseGateway
    {
        private IDBhelper _iDBhelper = null;

        public DatabaseGateway(string dbType)
        {
            try
            {
                //get the database handler based on the type of database
                _iDBhelper = DBHelperFactory.GetDBHelper(dbType);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ExecuteDataset(string query)
        {
            DataSet ds = null;
            try
            {
                ds= _iDBhelper.ExecuteDataset(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }

        public T ExecuteScalar<T>(string query)
        {
            T retValue = default(T);
            try
            {
             
                retValue = (T)_iDBhelper.ExecuteScalar(query);
                return retValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retValue;

        }


        public int ExecuteNonQuery(string query)
        {
            var retValue = -1;
            try
            {
                retValue = _iDBhelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retValue;
        }

        public int BulkInsert(List<string> queries)
        {
            var result = 0;
            try
            {
                _iDBhelper.BulkInsert(queries);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

            return result;
        }

        


    }
}
