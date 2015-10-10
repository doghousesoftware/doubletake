using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoubleTakeInventory.ConsignorClasses;
using DoubleTakeInventory.InventoryClasses;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace DoubleTakeInventory.UnitTests
{
    [TestClass]
    public class InventoryTests
    {
        const string testComment = "test comment";
        int testConsignor = 1;
        const string testConsignorName = "test consignor name";
        const string testDescription = "test description";
        decimal testPrice = 5;
        

        [TestMethod]
        public void AddInventory()
        {
            // setup
            int nextItem = GetMaxInventoryID();
            var i = new InventoryClasses.InventoryObject();
            var u = new InventoryClasses.InventoryUtilities();
            i.Comment = testComment;
            i.Consignor = testConsignor;
            i.ConsignorName = testConsignorName;
            i.Description = testDescription;
            i.Price = testPrice;
            
            // trigger
            int newItemID = u.SaveInventory(i);

            // validate
            Assert.AreEqual(nextItem, newItemID, "Expected next inventory item id");

        }

        private int GetMaxInventoryID()
        {
            int maxid = 0;
            string cmdText = "SELECT MAX(ITEMNUMBER) FROM DTUSER.NEWINVENTORY";
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                maxid = dr.GetSqlInt32(0).Value;
            }
            cn.Close();
            return maxid + 1;
        }
    }
}
