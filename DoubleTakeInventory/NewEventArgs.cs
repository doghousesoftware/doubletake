using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DoubleTakeInventory
{
    public class NewEventArgs : EventArgs
    {
        public int LineItemID { get; set; }
        public string QuantityChange { get; set; }
        public string PriceChange { get; set; }
        
    }

}
