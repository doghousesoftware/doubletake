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
    public partial class Report_InventorySelect : Form
    {
        public Report_InventorySelect()
        {
            InitializeComponent();
        }

        private void InventorySelect_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.Inventory_Select' table. You can move, or remove it, as needed.
            DateTime startDate = GlobalClass.RegisterStart;
            DateTime endDate = GlobalClass.RegisterEnd;
            var constrg = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
            this.Inventory_SelectTableAdapter.Connection = con;
            this.Inventory_SelectTableAdapter.Fill(this.DoubletakeDataSet.Inventory_Select, 0, startDate, endDate);
            this.reportViewer1.RefreshReport();
        }

        private void Inventory_SelectBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
