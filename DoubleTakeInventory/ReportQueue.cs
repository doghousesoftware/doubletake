using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace DoubleTakeInventory
{
    public partial class ReportQueue : Form
    {
        public ReportQueue()
        {
            InitializeComponent();
        }

                
        private void ReportQueue_Load(object sender, EventArgs e)
        {

            //ReportQueueItems.ClothesReport cr = new ReportQueueItems.ClothesReport();
            //this.flowReportQueue.Controls.Add(cr);

            //ReportQueueItems.DaysSales ds = new ReportQueueItems.DaysSales();
            //this.flowReportQueue.Controls.Add(ds);

            //ReportQueueItems.InventoryStatus invs = new ReportQueueItems.InventoryStatus();
            //this.flowReportQueue.Controls.Add(invs);

            //ReportQueueItems.SalesReport sr = new ReportQueueItems.SalesReport();
            //this.flowReportQueue.Controls.Add(sr);

            ReportQueueItems.SelectedInventory si = new ReportQueueItems.SelectedInventory();
            this.flowReportQueue.Controls.Add(si);

            ReportQueueItems.UnpaidSalesReport us = new ReportQueueItems.UnpaidSalesReport();
            this.flowReportQueue.Controls.Add(us);

            ReportQueueItems.ConsignorTransactions ct = new ReportQueueItems.ConsignorTransactions();
            this.flowReportQueue.Controls.Add(ct);

            //ReportQueueItems.SelectedConsignorReport scr = new ReportQueueItems.SelectedConsignorReport();
            //this.flowReportQueue.Controls.Add(scr);

        }

    }
}
