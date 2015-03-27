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
    public partial class SelectedInventory : UserControl
    {
        public SelectedInventory()
        {
            InitializeComponent();
        }

        private void cmdSelectedInventory_Click(object sender, EventArgs e)
        {
            DGInventory_Select tempReport = new DGInventory_Select();
            Form parentForm = (Form)this.Parent.Parent.Parent.Parent;
            tempReport.MdiParent = parentForm;
            tempReport.Show();
        }
    }
}
