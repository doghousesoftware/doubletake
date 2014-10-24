﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DoubleTakeInventory.ConsignorClasses
{
   


    public class ConsignorUtilities
    {
        /// <summary>
        /// Add a consignor to the database
        /// </summary>
        /// <param name="newconsignor"></param>
        /// <returns>New Consignor ID</returns>
        public virtual int AddNewConsignor(Consignor newconsignor)
        {
            int count;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
            SqlCommand cmd = new SqlCommand("DTUSER.NewConsignor_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pLastName", SqlDbType.NVarChar).Value = newconsignor.LastName;
                cmd.Parameters.Add("@pFirstName", SqlDbType.NVarChar).Value = newconsignor.FirstName;
                cmd.Parameters.Add("@pAddress1Street", SqlDbType.NVarChar).Value = newconsignor.Address1Street;
                cmd.Parameters.Add("@pAddress1City", SqlDbType.NVarChar).Value = newconsignor.Address1City;
                cmd.Parameters.Add("@pAddress1State", SqlDbType.NVarChar).Value = newconsignor.Address1State;
                cmd.Parameters.Add("@pAddress1Zip", SqlDbType.NVarChar).Value = newconsignor.Address1Zip;
                cmd.Parameters.Add("@pHomePhone", SqlDbType.NVarChar).Value = newconsignor.HomePhone;
                cmd.Parameters.Add("@pWorkPhone", SqlDbType.NVarChar).Value = newconsignor.WorkPhone;
                cmd.Parameters.Add("@pCellPhone", SqlDbType.NVarChar).Value = newconsignor.CellPhone;
                cmd.Parameters.Add("@pEmailAddress", SqlDbType.NVarChar).Value = newconsignor.EmailAddress;
                cmd.Parameters.Add("@pComments", SqlDbType.NVarChar).Value = newconsignor.Comments;
                cmd.Parameters.Add("@pDonate", SqlDbType.Bit).Value = newconsignor.Donate;
                cmd.Parameters.Add("@pCreateBy", SqlDbType.NVarChar).Value = "NewConsignor";

                cmd.ExecuteNonQuery();
                count = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
            }
            catch (SqlException sx)
            {
                Console.WriteLine(sx);
                count = -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                count = -2;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            return count;
        }

        /// <summary>
        /// Update an existing consignor based on consignor ID
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Success or Failure</returns>
        public virtual bool Consignor_Update(Consignor c)
        {
            bool returnValue = false;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
            SqlCommand cmd = new SqlCommand("DTUSER.Consignor_Update");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pConsignorID", SqlDbType.Int).Value = c.ConsignorID;
                cmd.Parameters.Add("@pLastName", SqlDbType.NVarChar).Value = c.LastName;
                cmd.Parameters.Add("@pFirstName", SqlDbType.NVarChar).Value = c.FirstName;
                cmd.Parameters.Add("@pAddress1Street", SqlDbType.NVarChar).Value = c.Address1Street;
                cmd.Parameters.Add("@pAddress1City", SqlDbType.NVarChar).Value = c.Address1City;
                cmd.Parameters.Add("@pAddress1State", SqlDbType.NVarChar).Value = c.Address1State;
                cmd.Parameters.Add("@pAddress1Zip", SqlDbType.NVarChar).Value = c.Address1Zip;
                cmd.Parameters.Add("@pHomePhone", SqlDbType.NVarChar).Value = c.HomePhone;
                cmd.Parameters.Add("@pWorkPhone", SqlDbType.NVarChar).Value = c.WorkPhone;
                cmd.Parameters.Add("@pCellPhone", SqlDbType.NVarChar).Value = c.CellPhone;
                cmd.Parameters.Add("@pEmailAddress", SqlDbType.NVarChar).Value = c.EmailAddress;
                cmd.Parameters.Add("@pComments", SqlDbType.NVarChar).Value = c.Comments;
                cmd.Parameters.Add("@pDonate", SqlDbType.Bit).Value = c.Donate;
                cmd.ExecuteNonQuery();
                returnValue = true;
            }
            catch (SqlException sx)
            {
                Console.WriteLine(sx);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            return returnValue;
        }


        /// <summary>
        /// check for valid consignor identification
        /// </summary>
        /// <param name="consignorID"></param>
        /// <returns></returns>
        public bool ValidConsignor(string consignorID)
        {
            bool returnValue = false;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
            SqlCommand cmd = new SqlCommand("DTUSER.ConsignorTest");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnParam = new SqlParameter("@Return_Value", DbType.Int32);
            returnParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnParam);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pConsignorID", SqlDbType.Int).Value = int.Parse(consignorID);
                cmd.ExecuteNonQuery();

                int iReturn = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
                if (iReturn != 0)
                {
                    returnValue = true;
                }
            }
            catch (SqlException sx)
            {
                Console.WriteLine(sx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            return returnValue;
        }
    }


    public class Consignor
    {
        public int ConsignorID {get;set;}
        public string LastName {get;set;}
        public string FirstName {get;set;}
        public string Address1Street {get;set;}
        public string Address1City {get;set;}
        public string Address1State { get; set; }
        public string Address1Zip {get;set;}
        public string HomePhone {get;set;}
        public string WorkPhone {get;set;}
        public string CellPhone {get;set;}
        public string EmailAddress {get;set;}
        public string Comments {get;set;}
        public bool Donate {get;set;}
        public string CreateBy { get; set; }
    }

}
