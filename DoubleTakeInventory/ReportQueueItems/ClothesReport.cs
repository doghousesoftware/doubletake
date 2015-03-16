using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleTakeInventory.ReportQueueItems
{
    public partial class ClothesReport : UserControl
    {
        public ClothesReport()
        {
            InitializeComponent();
        }



        


        private void cmdClothesReport_Click(object sender, EventArgs e)
        {
            GlobalClass.ClothesReport_Date = dateTimePicker1.Value.ToShortDateString();

            Report_DueDate RDD = new Report_DueDate();
            Form parentForm = (this.Parent as Form);
            RDD.MdiParent = parentForm;
            RDD.Show();
        }
    }
}
