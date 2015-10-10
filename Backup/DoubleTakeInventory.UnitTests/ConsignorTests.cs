using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoubleTakeInventory.ConsignorClasses;
using System.Data;
using System.Data.SqlClient;
using System.Xml;


namespace DoubleTakeInventory.UnitTests
{
    [TestClass]
    public class ConsignorTests
    {
        private const string testAddressCity = "TestAddressCity";
        private const string testAddressState = "ST";
        private const string testStreet = "TestStreet";
        private const string testZip = "99999";
        private const string testCell = "1231231234";
        private const string testComments = "test comments";
        private const string testEmail = "a@b.c";
        private const string testFirstName = "FirstName";
        private const string testHomePhone = "1231231234";
        private const string testLastName = "TestLastName";
        private const string testWorkPhone = "1231231234";
        private const string testUpdatedLastName = "UpdatedLastName";
        private const string testUpdatedFirstName = "UpdatedFirstName";

        [TestMethod]
        public void AddConsignor()
        {
            // SETUP
            int nextConsignor = GetMaxConsignorID() + 1;
            ConsignorClasses.Consignor c = new Consignor();
            ConsignorClasses.ConsignorUtilities u = new ConsignorUtilities();
            c.Address1City = testAddressCity;
            c.Address1State = testAddressState;
            c.Address1Street = testStreet;
            c.Address1Zip = testZip;
            c.CellPhone = testCell;
            c.Comments = testComments;
            c.ConsignorID = 0;
            c.Donate = true;
            c.EmailAddress = testEmail;
            c.FirstName = testFirstName;
            c.HomePhone = testHomePhone;
            c.LastName = testLastName;
            c.WorkPhone = testWorkPhone;

            // TRIGGER
            int newConsignorID = u.AddNewConsignor(c);

            // VALIDATE
            Assert.AreEqual(nextConsignor, newConsignorID, "expected different number");
        }

        [TestMethod]
        public void UpdateConsignor()
        {
            // SETUP
            ConsignorClasses.Consignor c = new Consignor();
            ConsignorClasses.ConsignorUtilities u = new ConsignorUtilities();
            c.Address1City = testAddressCity;
            c.Address1State = testAddressState;
            c.Address1Street = testStreet;
            c.Address1Zip = testZip;
            c.CellPhone = testCell;
            c.Comments = testComments;
            c.ConsignorID = GetMaxConsignorID();
            c.Donate = true;
            c.EmailAddress = testEmail;
            c.FirstName = testUpdatedFirstName;
            c.HomePhone = testHomePhone;
            c.LastName = testUpdatedLastName;
            c.WorkPhone = testWorkPhone;

            // TRIGGER
            bool updateResult = u.Consignor_Update(c);
            ConsignorClasses.Consignor updated = new Consignor();
            updated = u.GetExistingConsignor(GetMaxConsignorID());

            // VALIDATE
            Assert.AreEqual(true, updateResult, "expected different result");
            Assert.AreEqual(c.LastName, updated.LastName, "expected same updated last name");
            Assert.AreEqual(c.FirstName, updated.FirstName, "expected same updated first name");
        }

        private int GetMaxConsignorID()
        {
            int maxid = 0;
            string cmdText = "SELECT MAX(CONSIGNORID) FROM DTUSER.NEWCONSIGNOR";
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
            return maxid;
        }
    }
}
