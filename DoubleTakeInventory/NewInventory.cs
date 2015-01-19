using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleTakeInventory
{
    public partial class NewInventory : Form
    {
        /// <summary>
        /// Initialize form
        /// </summary>
        public NewInventory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load new inventory data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInventory_Load(object sender, EventArgs e)
        {
            GlobalClass gc = new GlobalClass();
            if (GlobalClass.ConsignerID != 0)
            {
                txtConsignorName.Text = GlobalClass.ConsignerSearchName;
                txtConsignerID.Text = GlobalClass.ConsignerID.ToString();
                
                txtConsignerID.Enabled = false;
                txtConsignorName.Enabled = false;
                gc.ClearEverything();
            }
            else
            {
                txtConsignerID.Enabled = true;
                txtConsignorName.Enabled = true;
            }
            dgInventoryColumns();
        }

        /// <summary>
        /// Define the inventory columns
        /// </summary>
        private void dgInventoryColumns()
        {
            dgInventory.Columns.Add("ItemDescription","Item Description");
            dgInventory.Columns["ItemDescription"].Width = 400;
            dgInventory.Columns.Add("AskingPrice", "Asking Price");
            dgInventory.Columns["AskingPrice"].Width = 100;
            dgInventory.Columns["AskingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgInventory.Columns.Add("Comment", "Comment");
            dgInventory.Columns["Comment"].Width = 200;
        }

        /// <summary>
        /// Save inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            //Save new inventory, then print labels
            if (DoValidations() == true)
            {
                if (SaveInventory() == true)
                {
                    BarCodePrinting();
                }
                else
                {
                    MessageBox.Show("Fatal Data Input Error", "New Inventory", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Some data enterd is not correct", "New Inventory", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// validations
        /// </summary>
        /// <returns></returns>
        private bool DoValidations()
        {
            if (txtConsignerID.Text == "")
            {
                return false;
            }

            if (txtConsignerID.Text != "")
            {
                try
                {
                    int itest = int.Parse(txtConsignerID.Text.ToString());
                }
                catch
                {
                    return false;
                }
            }

            // valid consignor?
            ConsignorClasses.ConsignorUtilities cu = new ConsignorClasses.ConsignorUtilities();
            if (!cu.ValidConsignor(txtConsignerID.Text))
            {
                return false;
            }

            // NOW test the data grid
            if (dgInventory.Rows.Count == 1)
            {
                return false;
            }

            for (int iRow = 0; iRow < dgInventory.Rows.Count -1; iRow++)
            {
                if (dgInventory[0, iRow].Value == null)
                {
                    return false;
                }
                try
                {
                    decimal dTest = decimal.Parse(dgInventory[1, iRow].Value.ToString());
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Decimal price check
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        private bool DecimalCheck(string sValue)
        {
            try
            {
                decimal scheck = decimal.Parse(sValue.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// bar code printing
        /// </summary>
        private void BarCodePrinting()
        {
            DialogResult dr = MessageBox.Show("New Inventory Entered - Print BARCODES now?", "New Inventory", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //spawn the print dialog for these current items
                BarCodePrinting childForm = new BarCodePrinting();
                childForm.MdiParent = this.MdiParent;
                childForm.Show();
            }
                this.Close();
        }

        /// <summary>
        /// remove lines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Remove this line");
        }

       
        /// <summary>
        /// Save inventory to the database
        /// </summary>
        /// <returns></returns>
        private bool SaveInventory()
        {
            for (int iRowCount = 0; iRowCount < dgInventory.Rows.Count-1; iRowCount++)
            {
                InventoryClasses.InventoryObject newInventory = new InventoryClasses.InventoryObject();
                newInventory.Consignor = int.Parse(txtConsignerID.Text.ToString());
                newInventory.Description = dgInventory[0, iRowCount].Value.ToString();
                newInventory.Price = decimal.Parse(dgInventory[1, iRowCount].Value.ToString());
                string comment = string.Empty;
                if (dgInventory[2, iRowCount].Value != null)
                {
                    comment = dgInventory[2, iRowCount].Value.ToString();
                }
                newInventory.Comment = comment;
                InventoryClasses.InventoryUtilities iu = new InventoryClasses.InventoryUtilities();
                int returnValue = iu.SaveInventory(newInventory);
                if (returnValue == -1)
                {
                    return false;
                }
            }
            return true;
        }

      
        /// <summary>
        /// resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInventory_Resize(object sender, EventArgs e)
        {
            dgInventory.Width = this.Width - 50;
        }

        /// <summary>
        /// cancel form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
