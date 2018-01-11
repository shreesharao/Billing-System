using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;
using System.IO;
using Utility.LogHelper;

namespace Utility.DatabaseHelper
{
    class SQLiteHelper : IDBhelper
    {
        private static string _databaseDirectory = string.Empty;
        private const string _databaseFile = "BillingSystem.sqlite";
        private SQLiteConnection _objSQLiteConnection = null;

        public static String ConnectionString
        {
            get
            {
                return "Data Source=" + _databaseDirectory + "\\" + _databaseFile + ";version=3";
            }
        }

        public SQLiteHelper()
        {
            //  CreateTable();
            _databaseDirectory = GetDatabaseDirecotry();

            //if (!Directory.Exists(_databaseDirectory))
            //{
            //    Directory.CreateDirectory(databaseDirectory);

            //}
            //if(File.Exists(Path.GetFullPath(databaseDirectory) +"\\" +databaseFile)
        }


        //public SQLiteConnection GetConnection()
        //{
        //    try
        //    {
        //        _objSQLiteConnection = new SQLiteConnection(ConnectionString);

        //        if (_objSQLiteConnection.State == ConnectionState.Closed)
        //        {
        //            _objSQLiteConnection.Open();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //    return _objSQLiteConnection;

        //}
        //public void CloseConnection()
        //{
        //    try
        //    {
        //        if (_objSQLiteConnection.State == ConnectionState.Open)
        //        {
        //            _objSQLiteConnection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        /// <summary>
        /// Returns single result
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query)
        {
            object result = 0;
            try
            {
                using (_objSQLiteConnection = new SQLiteConnection(ConnectionString))
                {
                    _objSQLiteConnection.Open();
                    SQLiteCommand objCmd = new SQLiteCommand(query, _objSQLiteConnection);
                    result = objCmd.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Database exception", ex);
            }
            finally
            {
                _objSQLiteConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Retruns a dataset
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet ExecuteDataset(string query)
        {
            DataSet dsResult = new DataSet();

            try
            {
                using (_objSQLiteConnection = new SQLiteConnection(ConnectionString))
                {
                    _objSQLiteConnection.Open();
                    SQLiteDataAdapter objDA = new SQLiteDataAdapter(query, _objSQLiteConnection);
                    objDA.Fill(dsResult);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Database exception", ex);
            }
            finally
            {
                _objSQLiteConnection.Close();
            }


            return dsResult;
        }

        /// <summary>
        /// Returns number of rows affected
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query)
        {
            int result = 0;
            try
            {
                using (_objSQLiteConnection = new SQLiteConnection(ConnectionString))
                {
                    _objSQLiteConnection.Open();
                    SQLiteCommand objCmd = new SQLiteCommand(query, _objSQLiteConnection);
                    result = objCmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Database exception", ex);
            }

            finally
            {
                _objSQLiteConnection.Close();
            }
            return result;

        }

        /// <summary>
        /// Returns SQLiteDataReader
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteReader(string query)
        {
            SQLiteDataReader objDR = null;

            try
            {
                using (_objSQLiteConnection = new SQLiteConnection(ConnectionString))
                {
                    _objSQLiteConnection.Open();
                    SQLiteCommand objCmd = new SQLiteCommand(query, _objSQLiteConnection);
                    objDR = objCmd.ExecuteReader();
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Database exception", ex);
            }
            finally
            {
                _objSQLiteConnection.Close();
            }

            return objDR;

        }

        /// <summary>
        /// Bulk inserts data.In case of exception transaction is rolled back
        /// </summary>
        /// <param name="lstQueries"></param>
        /// <returns></returns>
        public int BulkInsert(List<string> lstQueries)
        {
            var result = lstQueries.Count;
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                using (_objSQLiteConnection = new SQLiteConnection(ConnectionString))
                {
                    _objSQLiteConnection.Open();
                    using (SQLiteCommand objCmd = new SQLiteCommand(_objSQLiteConnection))
                    {
                        foreach (var query in lstQueries)
                        {
                            strBuilder.Append(query);
                        }
                        using (var transaction = _objSQLiteConnection.BeginTransaction())
                        {
                            try
                            {
                                objCmd.CommandText = strBuilder.ToString();
                                result = objCmd.ExecuteNonQuery();
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw ex;
                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _objSQLiteConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Returns database directory
        /// </summary>
        /// <returns></returns>
        private string GetDatabaseDirecotry()
        {
            return Path.GetFullPath(@"../..././../Database");
        }

        private void CreateTable()
        {

        }
    }
}
