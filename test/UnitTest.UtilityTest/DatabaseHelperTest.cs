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
            DatabaseGateway objDatabaseGateway = new DatabaseGateway("Utility.DatabaseHelper.SQLiteHelper");
            var items = objDatabaseGateway.ExecuteNonQuery("select * from TB_ITEMS");
            Assert.IsNotNull(items);
        }


        [TestMethod]
        public void BulkInsertTest()
        {
            DatabaseGateway objDatabaseGateway = new DatabaseGateway("Utility.DatabaseHelper.SQLiteHelper");
            List<string> lstQueries = new List<string>();

            for (int i = 2104; i < 2200; i++)
            {
               // var query="INSERT INTO TB_ITEMS(ItemName,Quantity) values('@iname',@qn);";
                var query = "Insert into tb_item_details(itemid,purchasedquantity,purchasedprice,purchasedfrom,purchaseddate) values(@iId,@pq,@pp,'@pf','@pd');";
                //query=query.Replace("@iname", "Test" + i);
                //query=query.Replace("@qn", "50");
                query = query.Replace("@iId", i.ToString());
                query = query.Replace("@pq", "20");
                query = query.Replace("@pp", "100");
                query = query.Replace("@pf", "test");
                query = query.Replace("@pd", DateTime.Now.Date.ToString());
 
                
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
