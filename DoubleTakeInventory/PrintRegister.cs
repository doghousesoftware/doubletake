using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Settings = DoubleTakeInventory.Properties.Settings;
using GlobalClass = DoubleTakeInventory.GlobalClass;


namespace DoubleTakeInventory
{
    public class PrintRegister
    {
        /// <summary>
        /// Prints a register tape
        /// </summary>
        /// <param name="invoiceid"></param>
        /// <param name="SalesRegister"></param>
        /// <param name="Saletype"></param>
        /// <param name="SubTotal"></param>
        /// <param name="Discount"></param>
        /// <param name="Taxes"></param>
        /// <param name="TotalSale"></param>
        /// <param name="dDateTime"></param>
        public void PrintTape(int invoiceid, Register SalesRegister, int Saletype, double SubTotal, double Discount, double Taxes, double TotalSale , DateTime dDateTime)
        {
            RegisterPrint rp = new RegisterPrint();
            string PrinterName = GlobalClass.RegisterPrinter;
            rp.Print(invoiceid, SalesRegister, Saletype, SubTotal, Discount, Taxes, TotalSale, dDateTime, PrinterName);
        }
        
        
        /// <summary>
        /// Prepares the register for the sale
        /// </summary>
        /// <param name="SalesRegister"></param>
        /// <param name="SaleType"></param>
        /// <param name="SubTotal"></param>
        /// <param name="Discount"></param>
        /// <param name="Taxes"></param>
        /// <param name="TotalSale"></param>
        /// <returns></returns>
        public bool PrintSale(Register SalesRegister, int SaleType, double SubTotal, double Discount, double Taxes, double TotalSale)
        {
            System.DateTime  dDateTime = System.DateTime.Now;
            int InvoiceID = -1;
            InvoiceID = RecordSale(SaleType, SubTotal, Discount, Taxes, TotalSale, dDateTime);
            if (InvoiceID != -1)
            {
                bool bResult = false;
                foreach (SoldLineItem item in SalesRegister.Sale)
                {
                    bResult = RecordSaleDetails(InvoiceID, item.LineItemID, item.ItemID, item.Description, item.Price, item.Quantity, item.Extended);
                    if (bResult == false)
                    {
                        return bResult;
                    }
                    bResult = RecordOldSale(item.ItemID, item.Price);
                    if (bResult == false)
                    {
                        return bResult;
                    }
                }
                
                PrintTape(InvoiceID, SalesRegister, SaleType, SubTotal, Discount, Taxes, TotalSale, dDateTime);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// records hte sale and returns the invoice id
        /// </summary>
        /// <param name="Saletype"></param>
        /// <param name="SubTotal"></param>
        /// <param name="Discount"></param>
        /// <param name="Taxes"></param>
        /// <param name="Total"></param>
        /// <param name="dDateTime"></param>
        /// <returns>Invoice ID</returns>
        public int RecordSale(int Saletype, double SubTotal, double Discount, double Taxes, double Total, DateTime dDateTime)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("dtuser.SalesRegister_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pMethod", SqlDbType.Int).Value = Saletype;
                cmd.Parameters.Add("@pSubTotal", SqlDbType.Money).Value = SubTotal;
                cmd.Parameters.Add("@pDiscount", SqlDbType.Money).Value = Discount;
                cmd.Parameters.Add("@pTax", SqlDbType.Money).Value = Taxes;
                cmd.Parameters.Add("@pTotal", SqlDbType.Money).Value = Total;
                cmd.Parameters.Add("@pSaleDate", SqlDbType.DateTime).Value = dDateTime;
                cmd.ExecuteNonQuery();

                int iReturn = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
                if (iReturn == -1)
                {
                    return -1;
                }
                else
                {
                    return iReturn;
                }
            }
            catch (SqlException)
            {
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public bool RecordSaleDetails(int InvoiceId, int LineItem, int ItemID, string Description, double Price, int Quantity, double Extended)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("dtuser.SalesDetails_Insert");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pInvoiceID", SqlDbType.Int).Value = InvoiceId;
                cmd.Parameters.Add("@pLineItem", SqlDbType.Int).Value = LineItem;
                cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = ItemID;
                cmd.Parameters.Add("@pItemDescription", SqlDbType.NVarChar).Value = Description;
                cmd.Parameters.Add("@pPrice", SqlDbType.Money).Value = Price;
                cmd.Parameters.Add("@pQuantity", SqlDbType.Int).Value = Quantity;
                cmd.Parameters.Add("@pExtended", SqlDbType.Money).Value = Extended;
                
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return true;
            }
            catch (SqlException)
            {
                return false;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        /// <summary>
        /// Records a sale in the old sales register
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        public bool RecordOldSale(int ItemID, double Price)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("dtuser.ItemSold_Insert");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = ItemID;
                cmd.Parameters.Add("@pSalePrice", SqlDbType.Money).Value = Price;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
    }
}
