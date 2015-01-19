using System;
using DoubleTakeInventory;
using DoubleTakeInventory.ConsignorClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Doubletake.Test
{
    [TestClass]
    public class ConsignorTests
    {
        public const string ConsignorNameLast = "LastName";
        public const string ConsignorNameFirst = "FirstName";
        public const string ConsignorStreet = "Address1";
        public const string ConsignorCity = "City";
        public const string ConsignorState = "ST";
        public const string ConsignorZip = "99999-9999";
        public const string ConsignorHomePhone = "(555) 555-1212";
        public const string ConsignorCellPhone = "(555) 555-1212";
        public const string ConsignorWorkPhone = "(555) 555-1212";
        public const string ConsignorComments = "asdfasdf asdfasdf asdfasdf asdfasdf";
        public const string ConsignorCreateBy = "TESTCASE";
        public const bool ConsignorDonate = false;
        public const string ConsignorEmail = "consignor@consignor.com";



        [TestMethod]
        public void NewConsignor_Add_Verify()
        {
            // SETUP
            Consignor c = new Consignor();
            ConsignorUtilitiesTesting cu = new ConsignorUtilitiesTesting();
            c.Address1City = ConsignorCity;
            c.Address1State = ConsignorState;
            c.Address1Street = ConsignorStreet;
            c.Address1Zip = ConsignorZip;
            c.CellPhone = ConsignorCellPhone;
            c.Comments = ConsignorComments;
            c.CreateBy = ConsignorCreateBy;
            c.Donate = ConsignorDonate;
            c.EmailAddress = ConsignorEmail;
            c.FirstName = ConsignorNameFirst;
            c.HomePhone = ConsignorHomePhone;
            c.LastName = ConsignorNameLast;
            c.WorkPhone = ConsignorWorkPhone;

            // TRIGGER
            c.ConsignorID = cu.AddNewConsignor(c);

            // VALIDATE
            Assert.IsTrue(c.ConsignorID == 5);
        }

        [TestMethod]
        public void UpdateConsignor_Verify()
        {
            // SETUP
            Consignor c = new Consignor();
            ConsignorUtilitiesTesting cu = new ConsignorUtilitiesTesting();
            c.Address1City = ConsignorCity;
            c.Address1State = ConsignorState;
            c.Address1Street = ConsignorStreet;
            c.Address1Zip = ConsignorZip;
            c.CellPhone = ConsignorCellPhone;
            c.Comments = ConsignorComments;
            c.CreateBy = ConsignorCreateBy;
            c.Donate = ConsignorDonate;
            c.EmailAddress = ConsignorEmail;
            c.FirstName = ConsignorNameFirst;
            c.HomePhone = ConsignorHomePhone;
            c.LastName = ConsignorNameLast;
            c.WorkPhone = ConsignorWorkPhone;

            // TRIGGER
            bool result = cu.Consignor_Update(c);
            
            // VALIDATE
            Assert.IsTrue(result);
        }

    }
}
