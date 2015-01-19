using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoubleTakeInventory;
using DoubleTakeInventory.InventoryClasses;

namespace Doubletake.Test
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void NewInventory_Add()
        {
            //  SETUP
            InventoryObject io = new InventoryObject();
            io.Consignor = 5;
            io.Description = "Test Inventory Object";
            io.Price = 123.45M;
            io.Comment = "Comment";

            // TRIGGER
            MockInventoryUtilities t = new MockInventoryUtilities();
            bool actualResult = t.SaveInventory(io);


            // VALIDATE
            Assert.IsTrue(actualResult);


        }
    }
}
