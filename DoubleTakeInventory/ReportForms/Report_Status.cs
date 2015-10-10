using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleTakeInventory
{
    public partial class Report_Status : Form
    {
        public Report_Status()
        {
            InitializeComponent();
        }

        private void Report_Status_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.SoldStatus_Report' table. You can move, or remove it, as needed.
            var d = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(d.ConnectionString);
            this.SoldStatus_ReportTableAdapter.Connection = con;
            this.SoldStatus_ReportTableAdapter.Fill(this.DoubletakeDataSet.SoldStatus_Report, GlobalClass.WhateverInt);
            this.reportViewer1.RefreshReport();
        }
    }
}
