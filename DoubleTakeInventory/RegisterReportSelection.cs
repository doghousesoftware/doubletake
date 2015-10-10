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
    public partial class RegisterReportSelection : Form
    {
        public RegisterReportSelection()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalClass.RegisterStart = System.DateTime.Parse(dateTimePicker1.Value.ToString());
            GlobalClass.RegisterEnd = System.DateTime.Parse(dateTimePicker2.Value.ToString());
            RegisterReport RR = new RegisterReport();
            RR.MdiParent = this.MdiParent;
            RR.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalClass.RegisterStart = System.DateTime.Parse(dateTimePicker1.Value.ToString());
            GlobalClass.RegisterEnd = System.DateTime.Parse(dateTimePicker2.Value.ToString());
            Report_RegisterSales RR = new Report_RegisterSales();
            RR.MdiParent = this.MdiParent;
            RR.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalClass.RegisterStart = System.DateTime.Parse(dateTimePicker1.Value.ToString());
            GlobalClass.RegisterEnd = System.DateTime.Parse(dateTimePicker2.Value.ToString());
            Report_ShopSales RS = new Report_ShopSales();
            RS.MdiParent = this.MdiParent;
            RS.Show();
        }

        
        private void RegisterReportSelection_Load(object sender, EventArgs e)
        {
            
        }
    }
}
