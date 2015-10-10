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
    public partial class ReportDaysSales : Form
    {
        public ReportDaysSales()
        {
            InitializeComponent();
        }

        private void ReportDaysSales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.ConsignorDaysSales' table. You can move, or remove it, as needed.
            var constrg = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
            this.ConsignorDaysSalesTableAdapter.Connection = con;
            this.ConsignorDaysSalesTableAdapter.Fill(this.DoubletakeDataSet.ConsignorDaysSales, GlobalClass.ConsignerID);
            this.reportViewer1.RefreshReport();
        }
    }
}
