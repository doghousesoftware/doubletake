using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DoubleTakeInventory.InventoryClasses
{
    
    public class InventoryUtilities
    {
        public int SaveInventory(InventoryObject newInventory)
        {
            int newInventoryID = 0;
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.Inventory_Insert");
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pConsignorID", SqlDbType.Int).Value = newInventory.Consignor;
                cmd.Parameters.Add("@pItemDescription", SqlDbType.NVarChar).Value = newInventory.Description;
                cmd.Parameters.Add("@pAskingPrice", SqlDbType.Decimal).Value = newInventory.Price;
                if (string.IsNullOrEmpty(newInventory.Comment))
                {
                    cmd.Parameters.Add("@pComment", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@pComment", SqlDbType.NVarChar).Value = newInventory.Comment;
                }
                
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                newInventoryID = (int)returnValue.Value;
            }
            catch (Exception)
            {
                newInventoryID = -1;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            return newInventoryID;
        }


        public InventoryObject GetInventoryDetails(string itemID)
        {
            InventoryObject returnItem = new InventoryObject();
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ItemID_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = itemID;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var foundInventory = new InventoryObject();
                    foundInventory.ItemID = dr.GetValue(0).ToString();
                    foundInventory.Description = dr.GetValue(1).ToString();
                    foundInventory.Price = dr.GetSqlMoney(2).Value;
                    foundInventory.DateIn = dr.GetSqlDateTime(3).Value;
                    //HAVE TO CHECK FOR NULL VALUES ON SOLD RANGE
                    if (dr.IsDBNull(4) == true)
                    {
                        foundInventory.SellPrice = 0;
                    }
                    else
                    {
                        foundInventory.SellPrice = dr.GetSqlMoney(4).Value;
                    }
                    
                    if (dr.IsDBNull(5) == true)
                    {
                        foundInventory.DateSold = DateTime.MinValue;
                    }
                    else
                    {
                        foundInventory.DateSold = dr.GetSqlDateTime(5).Value;
                    }


                    if (dr.IsDBNull(6) == true)
                    {
                        foundInventory.DatePaid = DateTime.MinValue; 
                    }
                    else
                    {
                        foundInventory.DatePaid = dr.GetSqlDateTime(6).Value;
                    }

                    if (dr.IsDBNull(7) == true)
                    {
                        foundInventory.PaidAmount = 0;
                    }
                    else
                    {
                        foundInventory.PaidAmount = dr.GetSqlMoney(7).Value;

                    }

                    foundInventory.Comment = dr.GetValue(8).ToString();
                    foundInventory.SoldStatus = dr.GetInt32(9);
                    foundInventory.Returnable = dr.GetBoolean(10);
                    foundInventory.Consignor = dr.GetSqlInt32(11).Value;
                    foundInventory.ConsignorName = dr.GetValue(13) + ", " + dr.GetValue(12);
                    foundInventory.Donate = dr.GetBoolean(14);
                    returnItem = foundInventory;
                }

                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if ( cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return returnItem;
        }


        /// <summary>
        /// updates a given inventory object
        /// </summary>
        /// <param name="io"></param>
        /// <returns></returns>
        public bool UpdateInventory(InventoryObject io)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.Inventory_Update");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = io.ItemID;
                cmd.Parameters.Add("@pItemDescription", SqlDbType.NVarChar).Value = io.Description;
                cmd.Parameters.Add("@pAskingPrice", SqlDbType.Decimal).Value = io.Price;
                cmd.Parameters.Add("@pSellingPrice", SqlDbType.Decimal).Value = io.SellPrice;
                cmd.Parameters.Add("@pComment", SqlDbType.NVarChar).Value = io.Comment;
                cmd.Parameters.Add("@pSoldStatus", SqlDbType.Int).Value = io.SoldStatus;
                cmd.Parameters.Add("@pReturned", SqlDbType.Bit).Value = io.Returnable;
                cmd.Parameters.Add("@pDateIn", SqlDbType.DateTime).Value = io.DateIn;
                
                if (DateTime.Compare(io.DateSold, DateTime.MinValue) == 0)
                {
                    cmd.Parameters.Add("@pDateSold", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@pDateSold", SqlDbType.DateTime).Value = io.DateSold;
                }

                if (DateTime.Compare(io.DatePaid, DateTime.MinValue) == 0)
                {
                    cmd.Parameters.Add("@pDatePaid", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@pDatePaid", SqlDbType.DateTime).Value = io.DatePaid;
                }
                                
                cmd.Parameters.Add("@pAmountPaid", SqlDbType.Money).Value = io.PaidAmount;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            return true;
        }
    }

    /// <summary>
    /// this is the main object for holding any inventory 
    /// </summary>
    public class InventoryObject
    {
        public int Consignor { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public string ItemID { get; set; }
        public DateTime DateIn { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime DateSold { get; set; }
        public DateTime DatePaid { get; set; }
        public decimal  PaidAmount { get; set; }
        public int SoldStatus { get; set; }
        public bool Returnable { get; set; }
        public string ConsignorName { get; set; }
        public bool Donate { get; set; }
    }
}
