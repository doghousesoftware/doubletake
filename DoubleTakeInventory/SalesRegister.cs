using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleTakeInventory
{
    public class SoldLineItem
    {
        private int lineitemid;
        public int LineItemID { 
            get
            {
                return lineitemid;
            }
            set
            {
                lineitemid = value;
            }
        }
        
        private int itemid;
        public int ItemID
        {
            get
            {
                return itemid;
            }
            set
            {
                itemid = value;
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        private double price;
        public double Price { 
            get
            {
                return price;
            }
            set
            {
                price = value;
                extended = Price * Quantity;
            } 
        }

        private int quantity;
        public int Quantity { 
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                extended = Price * Quantity;
            }
        }
        
        private double extended;
        public double Extended
        {
            get
            {
                return extended;
            }
            set
            {
                extended = value;
            }
        }
    }


    public class Register 
    {
        public List<SoldLineItem> Sale = new List<SoldLineItem>();
        
        public void Add(SoldLineItem _lineitem)
        {
            Sale.Add(_lineitem);
        }

        public void Update(int RowID, double Price, int Quantity)
        {
            foreach (SoldLineItem item in this.Sale)
            {
                if (item.LineItemID == RowID)
                {
                    item.Price = Price;
                    item.Quantity = Quantity;
                    item.Extended = item.Quantity * item.Price;
                }
            }
        }

        public SoldLineItem GetOneLine(int RowID)
        {
            SoldLineItem candidate = new SoldLineItem();
            foreach (SoldLineItem item in Sale)
            {
                if (item.LineItemID == RowID)
                {
                    candidate = item;
                }
            }
            return candidate;
        }

        public int RegisterCount()
        {
            return this.Sale.Count;
        }

        public void DeleteRow(int RowID)
        {
            SoldLineItem removeCandidate = new SoldLineItem();
            Sale.RemoveAt(RowID);
            
            // now reindex the rest of the line items
            foreach (SoldLineItem item in this.Sale)
            {
                if (item.LineItemID > RowID)
                {
                    item.LineItemID--;
                }
            }
        }

        /// <summary>
        /// calculate and return the SubTotal of the sale
        /// </summary>
        /// <returns></returns>
        public double SubTotal()
        {
            double dSubTotal = 0;
            foreach (SoldLineItem salesrow in this.Sale)
            {
                salesrow.Extended = salesrow.Price * salesrow.Quantity;
                dSubTotal += salesrow.Extended;
            }
            return dSubTotal;
        }
    }
}
