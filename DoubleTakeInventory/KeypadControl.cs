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
    public partial class KeypadControl : Form
    {
        public decimal KeypadControlResult { get; set; }
        public KeypadControl()
        {
            InitializeComponent();
        }

        private void cmdDecimal_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void cmd0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.BackColor = Color.White;
        }

        private void cmd1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void cmd2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void cmd3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void cmd4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void cmd5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void cmd6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void cmd7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void cmd8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void cmd9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void cmdEnter_Click(object sender, EventArgs e)
        {
            decimal dResult = 0;
            if (decimal.TryParse(textBox1.Text, out dResult))
            {
                KeypadControlResult = dResult;
                this.Close();
            }
            else
            {
                textBox1.BackColor = Color.Red;
            }
        }
    }
}
