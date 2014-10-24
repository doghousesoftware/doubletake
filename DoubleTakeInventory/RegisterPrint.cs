using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Settings = DoubleTakeInventory.Properties.Settings;
namespace DoubleTakeInventory
{
    public class RegisterPrint
    {
        public void Print(int invoiceid, Register SalesRegister, int Saletype, double SubTotal, double Discount, double Taxes, double TotalSale, DateTime dDateTime, string printerName)
        {
            const int PadSize = 11;
            const string RH = "S A L E S    R E G I S T E R";
            const string sSubTotal = "SubTotal";
            const string sDiscount = "Discount";
            const string sTaxes = "Taxes";
            const string sTotalSale = "Total Sale";

            string CompanyName = Settings.Default.CompanyName;
            string AddressLine1 = Settings.Default.AddressLine1;
            string AddressLine2 = Settings.Default.AddressLine2;
            string AddressLine3 = Settings.Default.AddressLine3;
            string FooterLine1 = Settings.Default.FooterLine1;
            string FooterLine2 = Settings.Default.FooterLine2;
            string RegisterHeader = RH;
            StringBuilder sb;

            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }

            sb = new StringBuilder();
            
            // Top of the page
            sb.AppendLine(CompanyName);
            sb.AppendLine(AddressLine1);
            sb.AppendLine(AddressLine2);
            sb.AppendLine(string.Empty);
            sb.AppendLine(RegisterHeader);
            sb.AppendLine(dDateTime.ToString().PadLeft(9) + " Receipt #: " + invoiceid.ToString());
            sb.AppendLine(string.Empty);
            sb.AppendLine(string.Empty);

            foreach (SoldLineItem item in SalesRegister.Sale)
            {
                if (item.Description.Length > 40)
                {
                    sb.AppendLine(item.Description.Substring(0, 40));
                }
                else
                {
                    sb.AppendLine(item.Description);
                }
                
                sb.AppendLine(item.ItemID.ToString().PadRight(15) + item.Price.ToString("c").PadLeft(PadSize) +  item.Quantity.ToString().PadLeft(5) + item.Extended.ToString("c").PadLeft(PadSize));
                
            }
            sb.AppendLine("------------------------------------------");
            sb.AppendLine(sSubTotal.PadRight(22) + SubTotal.ToString("c").PadLeft(20));
            sb.AppendLine(sDiscount.PadRight(22) + Discount.ToString("c").PadLeft(20));
            sb.AppendLine(sTaxes.PadRight(22) + Taxes.ToString("c").PadLeft(20));
            sb.AppendLine("                      --------------------");
            sb.AppendLine(sTotalSale.PadRight(22) + TotalSale.ToString("c").PadLeft(20));
            sb.AppendLine("                      ====================");

            //End of the Page
            sb.AppendLine(FooterLine1);
            sb.AppendLine(FooterLine2);
            for (int i = 0; i < 5; i++)
            {
                sb.AppendLine(string.Empty);
            }

            string GS = Convert.ToString((char)29);
            string ESC = Convert.ToString((char)27);

            Debug.Write(sb.ToString());
            sb.AppendLine(ESC + "@");
            sb.AppendLine(GS + "V" + (char)1);

            RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());
        }
    }

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "New Label";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }


        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}