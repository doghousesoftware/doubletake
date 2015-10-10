using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoubleTakeInventory;

namespace DoubleTakeInventory.UnitTests
{
    [TestClass]
    public class RegisterTests
    {
        public const string TestDescription = "test item description";
        public const int TestInventoryItem = 101010101;
        public const double TestPrice = 1.01;
        public const int TestQuantity = 1;
        public const double ExpectedExtended = 1.01;
        public const double ExpectedSubtotal = 1.01;

        [TestMethod]
        public void AddOneItemToRegister()
        {
            // setup
            Register r = new Register();
            var s1 = new SoldLineItem();
            
            // create a sale item
            s1.ItemID = TestInventoryItem;
            s1.Price = TestPrice;
            s1.Quantity = TestQuantity;
            s1.Description = TestDescription;
            
            // trigger
            r.Add(s1);

            // validate
            int registerCount = r.RegisterCount();
            double extended = s1.Extended;
            double subTotal = r.SubTotal();
            Assert.AreEqual(registerCount, 1, "expected register to have only 1 item");
            Assert.AreEqual(ExpectedSubtotal, subTotal, "expected different subtotal for 1 item");
            Assert.AreEqual(ExpectedExtended, extended, "expected different subtotal for 1 item");
        }

        [TestMethod]
        public void AddTenItemsToRegister()
        {
            // setup
            Register r = new Register();
            for (int i = 0; i < 10; i++)
            {
                var s1 = new SoldLineItem();

                // create a sale item
                s1.Description = TestDescription;
                s1.ItemID = TestInventoryItem;
                s1.Price = TestPrice;
                s1.Quantity = TestQuantity;

                // trigger
                r.Add(s1);
                s1 = null;
            }
            

            // validate
            int registerCount = r.RegisterCount();
            double subTotal = r.SubTotal();
            Assert.AreEqual(registerCount, 10, "expected register to have only 10 items");
            Assert.AreEqual(subTotal, 10.1, "expected different subtotal for 10 item");
        }

        [TestMethod]
        public void AddTenDifferentItemsToRegister()
        {
            // setup
            Register r = new Register();
            for (int i = 0; i < 10; i++)
            {
                var s1 = new SoldLineItem();

                // create a sale item
                s1.ItemID = TestInventoryItem;
                s1.Price = TestPrice * i;
                s1.Quantity = TestQuantity * i;

                // trigger
                r.Add(s1);
                s1 = null;
            }


            // validate
            int registerCount = r.RegisterCount();
            double subTotal = r.SubTotal();
            Assert.AreEqual(registerCount, 10, "expected register to have only 10 items");
            Assert.AreEqual(subTotal, 287.85, "expected different subtotal for 10 item");
        }

        [TestMethod]
        public void AddOneThousandDifferentItemsToRegister()
        {
            // setup
            Register r = new Register();
            for (int i = 0; i < 1000; i++)
            {
                var s1 = new SoldLineItem();

                // create a sale item
                s1.ItemID = TestInventoryItem;
                s1.Price = TestPrice * i;
                s1.Quantity = TestQuantity * i;

                // trigger
                r.Add(s1);
                s1 = null;
            }


            // validate
            int registerCount = r.RegisterCount();
            double subTotal = r.SubTotal();
            Assert.AreEqual(registerCount, 1000, "expected register to have only 10 items");
            Assert.AreEqual(subTotal, 336161835.0, "expected different subtotal for 10 item");
        }



        [TestMethod]
        public void AddItemRemoveItem()
        {
            // setup
            Register r = new Register();
            var s1 = new SoldLineItem();

            // create a sale item
            s1.ItemID = TestInventoryItem;
            s1.Price = TestPrice;
            s1.Quantity = TestQuantity;
            s1.Description = TestDescription;

            // trigger
            r.Add(s1);
            var registerLine = new SoldLineItem();

            registerLine = r.GetOneLine(0);
            // validate
            Assert.AreSame(TestDescription, registerLine.Description, "expected same descriptions");
            Assert.AreEqual(TestInventoryItem, registerLine.ItemID, "expected same inventory item id");
            Assert.AreEqual(TestPrice, registerLine.Price, "expected same price");
            Assert.AreEqual(TestQuantity, registerLine.Quantity, "expected same quantity");
            Assert.AreEqual((TestPrice * TestQuantity), registerLine.Extended, "expected same extension");
            Assert.AreEqual(0, registerLine.LineItemID, "expected first line item");

        }

        [TestMethod]
        public void AddOneItemToRegisterAndChangePrice()
        {
            // setup
            Register r = new Register();
            var s1 = new SoldLineItem();

            // create a sale item
            s1.ItemID = TestInventoryItem;
            s1.Price = TestPrice;
            s1.Quantity = TestQuantity;
            s1.Description = TestDescription;

            // trigger
            r.Add(s1);
            r.Update(0, 2, 1);

            // validate
            int registerCount = r.RegisterCount();
            double extended = s1.Extended;
            double subTotal = r.SubTotal();
            Assert.AreEqual(registerCount, 1, "expected register to have only 1 item");
            Assert.AreEqual(2, subTotal, "expected different subtotal for 1 item");
            Assert.AreEqual(2, extended, "expected different subtotal for 1 item");
        }

        [TestMethod]
        public void AddOneItemToRegisterAndChangePrice100Times()
        {
            // setup
            Register r = new Register();
            var s1 = new SoldLineItem();

            // create a sale item
            s1.ItemID = TestInventoryItem;
            s1.Price = TestPrice;
            s1.Quantity = TestQuantity;
            s1.Description = TestDescription;

            // trigger
            r.Add(s1);

            for (int i = 0; i < 100; i++)
            {
                r.Update(0, i, 1);
            }
            

            // validate
            int registerCount = r.RegisterCount();
            double extended = s1.Extended;
            double subTotal = r.SubTotal();
            Assert.AreEqual(registerCount, 1, "expected register to have only 1 item");
            Assert.AreEqual(99, subTotal, "expected different subtotal for 1 item");
            Assert.AreEqual(99, extended, "expected different subtotal for 1 item");
        }


        [TestMethod]
        public void Add100ItemsToRegisterAndChange1Price100Times()
        {
            // setup
            Register r = new Register();
            

            for (int i = 0; i < 100; i++)
            {
                var s1 = new SoldLineItem();
                // create a sale item
                s1.ItemID = TestInventoryItem;
                s1.Price = TestPrice * i;
                s1.Quantity = TestQuantity * i;
                s1.Description = TestDescription;

                // trigger
                r.Add(s1);
                s1 = null;
            }
            

            for (int i = 5; i < 55; i++)
            {
                r.Update(i, 23.4, 3);
            }

            for (int i = 45; i < 60; i++)
            {
                r.DeleteRow(i);
            }


            double subTotal = r.SubTotal();
            // validate
            int registerCount = r.RegisterCount();
            Assert.AreEqual(registerCount, 85, "expected register to have only 85 items");
            Assert.AreEqual(277765.14999999997, subTotal, "expected different subtotal");
        }


        [TestMethod]
        public void AddThreeItemsRemoveOneItem()
        {
            // setup
            Register r = new Register();

            for (int i = 0; i < 3; i++)
            {
                var s1 = new SoldLineItem();

                // create a sale item
                s1.LineItemID = i;
                s1.ItemID = TestInventoryItem;
                s1.Price = TestPrice;
                s1.Quantity = TestQuantity;
                s1.Description = TestDescription;

                // trigger
                r.Add(s1);
            }

            r.DeleteRow(1);

            Assert.AreEqual(r.RegisterCount(), 2, "expected 2 items");
            Assert.AreEqual(r.Sale[0].LineItemID, 0, "expected first item 0");
            Assert.AreEqual(r.Sale[1].LineItemID, 1, "expected second item 2");
        }

        [TestMethod]
        public void RemoveFirstItem()
        {
            // setup
            Register r = new Register();

            for (int i = 0; i < 3; i++)
            {
                var s1 = new SoldLineItem();

                // create a sale item
                s1.LineItemID = i;
                s1.ItemID = TestInventoryItem;
                s1.Price = TestPrice;
                s1.Quantity = TestQuantity;
                s1.Description = TestDescription;

                // trigger
                r.Add(s1);
            }

            r.DeleteRow(0);

            Assert.AreEqual(r.RegisterCount(), 2, "expected 2 items");
            Assert.AreEqual(r.Sale[0].LineItemID, 0, "expected first item 0");
            Assert.AreEqual(r.Sale[1].LineItemID, 1, "expected second item 2");
        }

        [TestMethod]
        public void AddTwoRemoveOneAddAgainUpdateLast()
        {
            // setup
            Register r = new Register();

            for (int i = 0; i < 2; i++)
            {
                var s1 = new SoldLineItem();

                // create a sale item
                s1.LineItemID = i;
                s1.ItemID = TestInventoryItem;
                s1.Price = i;
                s1.Quantity = i;
                s1.Description = TestDescription;

                // trigger
                r.Add(s1);
            }
            int removeIndex = r.RegisterCount();
            r.DeleteRow(removeIndex -1);

            var s2 = new SoldLineItem();

            // create a sale item
            s2.LineItemID = 3;
            s2.ItemID = TestInventoryItem;
            s2.Price = 3;
            s2.Quantity = 3;
            s2.Description = TestDescription;
            r.Add(s2);

            r.Update(2, 5, 5);
            Assert.AreEqual(r.RegisterCount(), 2, "expected 2 items");
            Assert.AreEqual(r.Sale[0].LineItemID, 0, "expected 0 for first");
            Assert.AreEqual(r.Sale[1].LineItemID, 3, "expected 3 for last");
        }
    }
}
