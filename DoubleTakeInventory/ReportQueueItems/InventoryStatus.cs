using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleTakeInventory.ReportQueueItems
{
    public partial class InventoryStatus : UserControl
    {
        public InventoryStatus()
        {
            InitializeComponent();
        }

        private void LoadComboBox_Status()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
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
                Form parentForm = (Form)this.Parent.Parent.Parent.Parent;
                RS.MdiParent = parentForm;
                RS.Show();
            }
        }
              

        private void InventoryStatus_Load(object sender, EventArgs e)
        {
            LoadComboBox_Status();
        }
    }
}
