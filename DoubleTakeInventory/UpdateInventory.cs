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
    public partial class UpdateInventory : Form
    {
        /// <summary>
        /// Initialize the form
        /// </summary>
        public UpdateInventory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// load the selected inventory item by the inventory number id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInventory_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            GlobalClass gc = new GlobalClass();
            // were we passed this form or asked to update?
            if ((GlobalClass.ConsignerID != 0) && (GlobalClass.InventoryID != string.Empty))
            {
                LoadDetails(int.Parse(GlobalClass.InventoryID.ToString()));
            }
            else
            {
                txtItemID.Enabled = true;
                cmdSearch.Visible = true;
            }
            
            gc.ClearEverything();
        }

        /// <summary>
        /// load up the found details for an inventory item
        /// </summary>
        /// <param name="ItemID"></param>
        private void LoadDetails(int ItemID)
        {
            try
            {
                InventoryClasses.InventoryUtilities iu = new InventoryClasses.InventoryUtilities();
                InventoryClasses.InventoryObject io = new InventoryClasses.InventoryObject();
                io = iu.GetInventoryDetails(ItemID.ToString());

                if (io == null)
                {
                    MessageBox.Show("There was a problem retrieving that inventory item", Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
                }
                else
                {
                    txtItemID.Text = io.ItemID;
                    txtDescription.Text = io.Description;
                    txtAskPrice.Text = decimal.Round(io.Price, 2).ToString();
                    txtDateIn.Text = io.DateIn.ToString();
                    txtSellPrice.Text = decimal.Round(io.SellPrice, 2).ToString();
                    if (DateTime.Compare(io.DateSold, DateTime.MinValue) == 0)
                    {
                        txtDateSold.Text = string.Empty;
                    }
                    else
                    {
                        txtDateSold.Text = io.DateSold.ToString();
                    }
                    if (DateTime.Compare(io.DatePaid, DateTime.MinValue) == 0)
                    {
                        txtDatePaid.Text = string.Empty;
                    }
                    else
                    {
                        txtDatePaid.Text = io.DatePaid.ToString();
                    }

                    txtPaidAmount.Text = decimal.Round(io.PaidAmount, 2).ToString();
                    txtComment.Text = io.Comment;
                    cboSoldStatus.SelectedIndex = io.SoldStatus;
                    this.ckReturn.Checked = io.Returnable;
                    txtConsignID.Text = io.Consignor.ToString();
                    txtConsignor.Text = io.ConsignorName;

                    if (io.Donate)
                    {
                        lblDonateCheck.Text = "x";
                    }
                    else
                    {
                        lblDonateCheck.Text = "o";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("There was an error: {0}", e.Message), Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// load the combo box for the sold status states
        /// </summary>
        private void LoadComboBox()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.SoldStatusComboBox");
            SqlDataReader dr;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboSoldStatus.Items.Add(dr.GetValue(0).ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("There was an error: {0}", e.Message), Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
            }
            finally
            {
                if ( cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }


        /// <summary>
        /// cancel the update and close the form without warning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// commence the validation and save of the updated inventory item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DoValidations() == true)
                {
                    //  CHECK IF THE SAVE IS TRUE
                    if (SaveInventoryItem() == true)
                    {
                        MessageBox.Show("Item Saved!", "Update Inventory", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please correct data!", "Inventory Data", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There was an error: {0}", ex.Message), Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// validations for the save of the updated inventory item
        /// </summary>
        /// <returns></returns>
        private bool DoValidations()
        {
            if (txtSellPrice.Text == string.Empty && txtDateSold.Text == string.Empty && txtDatePaid.Text == string.Empty )
            {
                return true;
            }
            else
            {
                if (txtAskPrice.Text != string.Empty)
                {
                    try
                    {
                        decimal.Parse(txtAskPrice.Text.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                }

                if (txtPaidAmount.Text != string.Empty)
                {
                    try
                    {
                        decimal.Parse(txtPaidAmount.Text.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                }

                if (txtSellPrice.Text != string.Empty)
                {
                    try
                    {
                        decimal.Parse(txtSellPrice.Text.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                }

                if (txtDateIn.Text != string.Empty)
                {
                    try
                    {
                        DateTime.Parse(txtDateIn.Text.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                }

                if (txtDateSold.Text != string.Empty)
                {
                        try
                    {
                        DateTime.Parse(txtDateSold.Text.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                }

                if (txtDatePaid.Text != string.Empty)
                {
                    try
                    {
                        DateTime.Parse(txtDatePaid.Text.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                }
               
            }
            return true;
        }

        /// <summary>
        /// save the inventory item
        /// </summary>
        /// <returns></returns>
        private bool SaveInventoryItem()
        {
            InventoryClasses.InventoryObject io = new InventoryClasses.InventoryObject();
            InventoryClasses.InventoryUtilities iu = new InventoryClasses.InventoryUtilities();

            io.ItemID = txtItemID.Text;
            io.Description = txtDescription.Text;
            decimal dpResult = 0;
            if (decimal.TryParse(txtAskPrice.Text, out dpResult))
            {
                io.Price = dpResult;
            }
            else
            {
                io.Price = dpResult;
            }

            decimal dsResult = 0;
            if (decimal.TryParse(txtSellPrice.Text, out dsResult))
            {
                io.SellPrice = dsResult;
            }
            else
            {
                io.SellPrice = dsResult;
            }

            io.Comment = txtComment.Text;
            io.SoldStatus = cboSoldStatus.SelectedIndex;
            io.Returnable = ckReturn.Checked;
            
            //CHECK FOR NULL DATES

            DateTime dtResult = DateTime.MinValue;
            if (DateTime.TryParse(txtDateIn.Text, out dtResult))
            {
                io.DateIn = dtResult;
            }
            else
            {
                io.DateIn = DateTime.MinValue;
            }

            if (DateTime.TryParse(txtDateSold.Text, out dtResult))
            {
                io.DateSold = dtResult;
            }
            else
            {
                io.DateSold = DateTime.MinValue;
            }

            if (DateTime.TryParse(txtDatePaid.Text, out dtResult))
            {
                io.DatePaid = dtResult;
            }
            else
            {
                io.DatePaid = DateTime.MinValue;
            }
            decimal pResult = 0;
            if (decimal.TryParse(txtPaidAmount.Text, out pResult))
            {
                io.PaidAmount = pResult;
            }
            else
            {
                io.PaidAmount = pResult;
            }
            
            bool returnValue = iu.UpdateInventory(io);
            return returnValue;
        }

        /// <summary>
        /// start a search for the inventory item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            LoadDetails(int.Parse(txtItemID.Text.ToString()));
        }

        /// <summary>
        /// load up the bar code for printing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReprintBarCode_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text != string.Empty)
            {
                var d = new Decode();
                SqlConnection cn = new SqlConnection(d.ConnectionString);
                SqlCommand cmd = new SqlCommand("DTUSER.WaitingToPrint_Insert");
                cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = txtItemID.Text;
            
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There was an error: {0}", ex.Message), Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
            }
            finally
            {
                if ( cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            MessageBox.Show("BarCode Added to Bar Code Print Queue!", "Manual Update", MessageBoxButtons.OK);
            }
        }
    }
}
