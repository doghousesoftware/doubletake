using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Controls;


namespace DoubleTakeInventory
{
    public partial class DGInventory_Select : Form
    {
        public int SoldOnly { get; set; }
        public DGInventory_Select()
        {
            InitializeComponent();
        }

        private void DGInventory_Select_Resize(object sender, EventArgs e)
        {
            if (this.Width > 700)
            {
                dataGridView1.Width = this.Width - 20;
            }

            if (this.Height > 500)
            {
                dataGridView1.Height = this.Height - 100;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            var constrg = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
            this.inventory_SelectTableAdapter.Connection = con;
            this.inventory_SelectTableAdapter.Fill(this.doubletakeDataSet.Inventory_Select, SoldOnly, startDate, endDate);
            dataGridView1.Refresh();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            this.dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }

        private void ckSoldOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoldOnly.Checked)
            {
                SoldOnly = 1;
            }
            else
            {
                SoldOnly = 0;
            }
        }
    }
}
