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
    public partial class DaysSales : Form
    {
        public DaysSales()
        {
            InitializeComponent();
        }

       

        private void cmdSubmit_Click(object sender, EventArgs e)
        {

            if (MoneyCheck() == true)
            {
                DialogResult dr;
                dr = MessageBox.Show("Confirm Days sales for " + calMonth.SelectionEnd.Date.ToShortDateString() + " and Amount of $" + txtDaysSales.Text.ToString(), "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SaveDaysSales();
                }
                this.Close();

            }
            else
            {
                MessageBox.Show("Please check your input!", "Money Validation", MessageBoxButtons.OK);
            }
            
            
        }

        private bool MoneyCheck()
        {
            try
            {
                Convert.ToDouble(txtDaysSales.Text);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void DaysSales_Load(object sender, EventArgs e)
        {
            calMonth.TodayDate = System.DateTime.Today;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calMonth_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime startD = calMonth.SelectionStart;

            string dateStartStr = startD.Date.ToShortDateString();
            
        }

        private void SaveDaysSales()
        {
            int count;
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.OtherDaysSales_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pSaleDate", SqlDbType.DateTime).Value = calMonth.SelectionStart.ToString();
            cmd.Parameters.Add("@pSaleAmount", SqlDbType.Money).Value = decimal.Parse(txtDaysSales.Text.ToString());
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                count = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
                MessageBox.Show("Record #: " + count.ToString() + " Entered!","Days Sales",MessageBoxButtons.OK);
                
            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString(), "SQL Data Error", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "C# Error", MessageBoxButtons.OK);
            }
            finally
            {
                if ( cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
    }
}
