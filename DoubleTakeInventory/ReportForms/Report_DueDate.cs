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
    public partial class Report_DueDate : Form
    {
        public Report_DueDate()
        {
            InitializeComponent();
        }

        private void Report_DueDate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.ClothesDueDate_Select' table. You can move, or remove it, as needed.
            var constrg = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
            this.ClothesDueDate_SelectTableAdapter.Connection = con;
            this.ClothesDueDate_SelectTableAdapter.Fill(this.DoubletakeDataSet.ClothesDueDate_Select, DateTime.Parse(GlobalClass.ClothesReport_Date));
            this.reportViewer1.RefreshReport();
        }
    }
}
