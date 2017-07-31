using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility.DatabaseHelper;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTest.DatabaseHelperTest
{
    [TestClass]
    public class DatabaseHelperTest
    {
        [TestMethod]
        public void CreateInstanceTest()
        {
            DatabaseGateway objDatabaseGateway = new DatabaseGateway();
            var items = objDatabaseGateway.ExecuteNonQuery("select * from TB_ITEMS");
            Assert.IsNotNull(items);
        }


        [TestMethod]
        public void BulkInsertTest()
        {
            DatabaseGateway objDatabaseGateway = new DatabaseGateway();
            List<string> lstQueries = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                var query="INSERT INTO TB_ITEMS(ItemName,Quantity) values('@iname',@qn);";
                query=query.Replace("@iname", "Test" + i);
                query=query.Replace("@qn", "50");
                lstQueries.Add(query);
            }
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            var items = objDatabaseGateway.BulkInsert(lstQueries);
            sw.Stop();
            var time = sw.ElapsedMilliseconds/1000;
            Assert.IsNotNull(items);
        }

    }
}
