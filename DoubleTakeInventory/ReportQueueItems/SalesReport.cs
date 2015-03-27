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
    public partial class SalesReport : UserControl
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void cmdSalesRenge_Click(object sender, EventArgs e)
        {
            DateTime date1, date2;
            //get the dates
            date1 = DateRange1.Value;
            date2 = DateRange2.Value;
            date1 = DateTime.Parse(date1.Month.ToString() + "-" + date1.Day.ToString() + "-" + date1.Year.ToString());
            date2 = DateTime.Parse(date2.Month.ToString() + "-" + date2.Day.ToString() + "-" + date2.Year.ToString() + " 11:59:59 PM");
            GlobalClass.RegisterStart = date1;
            GlobalClass.RegisterEnd = date2;

            Report_AllSales AS = new Report_AllSales();
            Form parentForm = (Form)this.Parent.Parent.Parent.Parent;
            AS.MdiParent = parentForm;
            AS.Show();
        }
    }
}
