using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleTakeInventory
{
    public partial class RegisterAdjustment : Form
    {
        public RegisterAdjustment()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (txtReceipt.Text != string.Empty)
            {
                int iReceipt;
                bool result = int.TryParse(txtReceipt.Text, out iReceipt);
                if (result == true)
                {
                    Process(iReceipt);
                }
                else 
                { 
                    MessageBox.Show("Invalid Receipt ID");
                }
            }
        }


       

        private void Process(int Receipt)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("dtuser.Register_Update");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pInvoiceID", SqlDbType.Int).Value = Receipt;

                dr = cmd.ExecuteReader();
            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString(),"Receipt Zero");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(),"Receipt Zero");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            MessageBox.Show("Receipt has been zeroed");
            this.Close();
        }
    }
}
