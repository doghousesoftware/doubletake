using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace DoubleTakeInventory
{
    public partial class ReportQueue : Form
    {
        int icount;
        public ReportQueue()
        {
            InitializeComponent();
        }

        private void cmdClothesReport_Click(object sender, EventArgs e)
        {
            GlobalClass.ClothesReport_Date = dateTimePicker1.Value.ToShortDateString();
            
            Report_DueDate RDD = new Report_DueDate();
            RDD.MdiParent = this.MdiParent;
            RDD.Show();
        }

        
        private void ReportQueue_Load(object sender, EventArgs e)
        {
            LoadComboBox_Status();
        }

        private void LoadComboBox_Status()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
            SqlCommand cmd = new SqlCommand("DTUSER.SoldStatusComboBox");
            SqlDataReader dr;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboSoldStatus.Items.Add(dr.GetValue(0).ToString());
                }

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
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void cmdInventoryStatus_Click(object sender, EventArgs e)
        {
            if (cboSoldStatus.SelectedIndex != -1)
            {
                 GlobalClass.RequestedReport = 2;
                 GlobalClass.WhateverInt = int.Parse(cboSoldStatus.SelectedIndex.ToString());

                Report_Status RS = new Report_Status();
                RS.MdiParent = this.MdiParent;
                RS.Show();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date2;
            //get the dates
            date2 = dateTimePicker2.Value;
            GlobalClass.ClothesReport_Date = date2.ToString();
            Report_PaymentsDue PD = new Report_PaymentsDue();
            PD.MdiParent = this.MdiParent;
            PD.Show();
        }


        private int AllSalesProc(DateTime StartDate, DateTime EndDate)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
            SqlCommand cmd = new SqlCommand("DTUSER.AllSales_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pStartDate", SqlDbType.DateTime).Value = StartDate;
                cmd.Parameters.Add("@pEndDate", SqlDbType.DateTime).Value = EndDate;
                cmd.ExecuteNonQuery();
                icount = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());

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
            return icount;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date1, date2;
            //get the dates
            date1 = DateRange1.Value;
            date2 = DateRange2.Value;
            date1 = DateTime.Parse(date1.Month.ToString() + "-" + date1.Day.ToString() + "-" + date1.Year.ToString());
            date2 = DateTime.Parse(date2.Month.ToString() + "-" + date2.Day.ToString() + "-" + date2.Year.ToString() + " 11:59:59 PM");
            GlobalClass.RegisterStart = date1;
            GlobalClass.RegisterEnd = date2;

            Report_AllSales AS = new Report_AllSales();
            AS.MdiParent = this.MdiParent;
            AS.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int iConID = 0;
            try
            {

                iConID = int.Parse(txtConsignorID.Text.ToString());
            }
            catch
            {
                iConID = 0;
            }

            GlobalClass.ConsignerID = iConID;
            ReportDaysSales PDS = new ReportDaysSales();
            PDS.MdiParent = this.MdiParent;
            PDS.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DGInventory_Select tempReport = new DGInventory_Select();
            tempReport.MdiParent = this.MdiParent;
            tempReport.Show();
        }

        
    }
}
