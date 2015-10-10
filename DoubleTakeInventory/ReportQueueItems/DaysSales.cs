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
    public partial class DaysSales : UserControl
    {
        public DaysSales()
        {
            InitializeComponent();
        }

        

        private void cmdConsignorDays_Click(object sender, EventArgs e)
        {
            int iConID = 0;
            try
            {

                iConID = int.Parse(txtConsignorID.Text.ToString());
            }
            catch
            {
                iConID = 0;
            }

            GlobalClass.ConsignerID = iConID;
            ReportDaysSales PDS = new ReportDaysSales();
            Form parentForm = (Form)this.Parent.Parent.Parent.Parent;
            PDS.MdiParent = parentForm;
            PDS.Show();

        }
    }
}
