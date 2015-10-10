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
    public partial class RegisterReport : Form
    {
        public RegisterReport()
        {
            InitializeComponent();
        }

        private void RegisterReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.SalesRegister_Select' table. You can move, or remove it, as needed.
            var constrg = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
            this.SalesRegister_SelectTableAdapter.Connection = con;
            this.SalesRegister_SelectTableAdapter.Fill(this.DoubletakeDataSet.SalesRegister_Select, GlobalClass.RegisterStart, GlobalClass.RegisterEnd);
            this.reportViewer1.RefreshReport();
        }
    }
}
