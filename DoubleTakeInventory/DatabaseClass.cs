using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DoubleTakeInventory
{
    class DatabaseClass
    {
        public SqlConnection NewConnection()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
            cn.Open();
            return cn;

        }

        public SqlCommand NewCommand(SqlConnection sqlCN, string CommandText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCN;
            
            cmd.CommandText = CommandText;
            return cmd;
        }

        public SqlDataReader NewDataReader(SqlCommand sqlCMD)
        {
            SqlDataReader dr;
            dr = sqlCMD.ExecuteReader();
            return dr;
        }

       

    }
}
