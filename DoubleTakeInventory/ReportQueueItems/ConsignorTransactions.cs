using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleTakeInventory.ReportQueueItems
{
    public partial class ConsignorTransactions : UserControl
    {
        public ConsignorTransactions()
        {
            InitializeComponent();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            GlobalClass gc = new GlobalClass();
            gc.ClearEverything();

            GlobalClass.RegisterStart = this.dateTimePicker1.Value;
            GlobalClass.RegisterEnd = this.dateTimePicker2.Value;
            
            Report_PickUpPayment pmt = new Report_PickUpPayment();
            Form parentForm = (Form)this.Parent.Parent.Parent.Parent;
            pmt.MdiParent = parentForm;
            pmt.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
