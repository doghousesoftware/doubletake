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
    public partial class UnpaidSalesReport : UserControl
    {
        public UnpaidSalesReport()
        {
            InitializeComponent();
        }

        private void cmdUnpaidSales_Click(object sender, EventArgs e)
        {
            DateTime date2;
            //get the dates
            date2 = dateTimePicker2.Value;
            GlobalClass.ClothesReport_Date = date2.ToString();
            Report_PaymentsDue PD = new Report_PaymentsDue();
            Form parentForm = (this.Parent as Form);
            PD.MdiParent = parentForm;
            PD.Show();
        }
    }
}
