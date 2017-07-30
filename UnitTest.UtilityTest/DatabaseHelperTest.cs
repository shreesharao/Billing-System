using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility.DatabaseHelper;

namespace UnitTest.DatabaseHelperTest
{
    [TestClass]
    public class DatabaseHelperTest
    {
        [TestMethod]
        public void CreateInstanceTest()
        {
            DatabaseGateway objDatabaseGateway = new DatabaseGateway();
            var items=objDatabaseGateway.ExecuteNonQuery("select * from TB_ITEMS");
            Assert.IsNotNull(items);
        }

    }
}
