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
    public partial class Report_PaymentsDue : Form
    {
        public Report_PaymentsDue()
        {
            InitializeComponent();
        }

        private void Report_PaymentsDue_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.PaymentsDue_Select' table. You can move, or remove it, as needed.
            var d = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(d.ConnectionString);
            this.PaymentsDue_SelectTableAdapter.Connection = con;
            this.PaymentsDue_SelectTableAdapter.Fill(this.DoubletakeDataSet.PaymentsDue_Select, System.DateTime.Parse(GlobalClass.ClothesReport_Date.ToString()));
            this.reportViewer1.RefreshReport();

        }

       

       
    }
}
