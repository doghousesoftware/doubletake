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
    public partial class PaymentPickups : Form
    {
        public PaymentPickups()
        {
            InitializeComponent();
        }

        private void PaymentPickups_Load(object sender, EventArgs e)
        {
            textBox1.Text = GlobalClass.ConsignerID.ToString();
        }
    }
}
