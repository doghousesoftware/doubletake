using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DoubleTakeInventory
{
    class dbPOS
    {
        public double SalesTaxRate()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString); 
            SqlCommand cmd = new SqlCommand("DTUser.SalesTaxRate_Select");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Decimal);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);
            SqlDataReader dr;
            
            try
            {
                double iReturn = -100;
                cn.Open();
                cmd.Connection = cn;
                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    iReturn = (double)dr.GetSqlDecimal(0).Value;
                }
                return iReturn;
            }
            catch (SqlException)
            {
                throw;

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
        }
    }
}
