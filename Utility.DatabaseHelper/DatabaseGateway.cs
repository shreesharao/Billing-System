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
        private static LogGateway _logGateway = null;

        public DatabaseGateway()
        {
            try
            {
                //get logger handler
                _logGateway = new LogGateway(this.GetType());

                var dbType = GetDatabaseTypeFromConfig();
                _logGateway.Info(string.Format("{0}:{1}","Database type",dbType));

                //get the database handler based on the type of database
                _iDBhelper = DBHelperFactory.GetDBHelper(dbType);
            }
            catch (Exception ex)
            {
                _logGateway.Error(ex);
            }

        }

        public DataSet ExecuteDataset(string query)
        {
            DataSet ds = null;
            try
            {
                _logGateway.Info(string.Format("ExecuteDataset-Query recieved:{0}", query));
                ds= _iDBhelper.ExecuteDataset(query);
            }
            catch (Exception ex)
            {
                _logGateway.Error(ex);
            }
            return ds;

        }

        public T ExecuteScalar<T>(string query)
        {
            T retValue = default(T);
            try
            {
                _logGateway.Info(string.Format("ExecuteScalar-Query recieved:{0}", query));
                retValue = (T)_iDBhelper.ExecuteScalar(query);
                return retValue;
            }
            catch (Exception ex)
            {
                _logGateway.Error(ex);
            }
            return retValue;

        }


        public int ExecuteNonQuery(string query)
        {
            var retValue = -1;
            try
            {
                _logGateway.Info(string.Format("ExecuteNonQuery-Query recieved:{0}", query));
                retValue = _iDBhelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                _logGateway.Error(ex);
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

        private string GetDatabaseTypeFromConfig()
        {
            var type = ConfigurationManager.AppSettings["DB"];

            return type.ToString();
        }


    }
}
