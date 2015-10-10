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
    public partial class Report_ShopSales : Form
    {
        public Report_ShopSales()
        {
            InitializeComponent();
        }

        private void Report_ShopSales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.ShopInventory_Select' table. You can move, or remove it, as needed.
            var d = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(d.ConnectionString);
            this.ShopInventory_SelectTableAdapter.Connection = con;
            this.ShopInventory_SelectTableAdapter.Fill(this.DoubletakeDataSet.ShopInventory_Select, GlobalClass.RegisterStart, GlobalClass.RegisterEnd);
            this.reportViewer1.RefreshReport();
        }
    }
}
