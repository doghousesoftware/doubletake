using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleTakeInventory
{   
    public class GlobalClass
    {
        public static int ConsignerID { get; set; }
        public static string ConsignerSearchName { get; set; }
        public static string InventoryID { get; set; }
        public static string InventoryDescription { get; set; }
        public static string ClothesReport_Date { get; set; }
        public static int RequestedReport { get; set; }
        public static int WhateverInt { get; set; }
        public static DateTime RegisterStart { get; set; }
        public static DateTime RegisterEnd { get; set; }
        public static double SalesTax { get; set; }
        public static string LabelPrinter { get; set; }
        public static string ReportPrinter { get; set; }
        public static string RegisterPrinter { get; set; }
        public static string WhateverString { get; set; }
        
        public void ClearEverything()
        {
            ConsignerID = 0;
            ConsignerSearchName = string.Empty;
            InventoryID = string.Empty;
            InventoryDescription = string.Empty;
            ClothesReport_Date = string.Empty;
            RequestedReport = 0;
            WhateverInt = 0;
        }
    }
}
