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
    public partial class Report_Global : Form
    {
        public Report_Global()
        {
            InitializeComponent();
        }

        private void Report_Global_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.ConsignorGlobalReport' table. You can move, or remove it, as needed.
            var constrg = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
            this.ConsignorGlobalReportTableAdapter.Connection = con;
            this.ConsignorGlobalReportTableAdapter.Fill(this.DoubletakeDataSet.ConsignorGlobalReport, GlobalClass.ConsignerID);
            this.reportViewer1.RefreshReport();
            
        }
    }
}
