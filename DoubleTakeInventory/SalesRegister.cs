using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DoubleTakeInventory
{
    public class SoldLineItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private int lineitemid;
        public int LineItemID { 
            get
            {
                return lineitemid;
            }
            set
            {
                lineitemid = value;
                OnPropertyChanged("LineItemID");
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
                OnPropertyChanged("ItemID");
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
                OnPropertyChanged("Description");
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
                OnPropertyChanged("Description");
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
                OnPropertyChanged("Quantity");
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
                OnPropertyChanged("Extended");
            }
        }

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }


    public class Register : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<SoldLineItem> Sale = new ObservableCollection<SoldLineItem>();
        
        public void Add(SoldLineItem _lineitem)
        {
            Sale.Add(_lineitem);
            OnPropertyChanged("Sale");
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
            OnPropertyChanged("Sale");
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
            OnPropertyChanged("Sale");
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

        
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
