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
    public partial class ReturnItems : Form
    {
        string col1;
        string col2;
        string col3;
        string col4;

        public ReturnItems()
        {
            InitializeComponent();
        }

        private void ReturnItems_Load(object sender, EventArgs e)
        {
            DataGridSetUp();
            txtScanBox.Focus();
        }

        private void DataGridSetUp()
        {
            dataGridView1.Columns.Add("ItemID", "ItemID");
            dataGridView1.Columns["ItemID"].Width = 100;
            dataGridView1.Columns["ItemID"].ReadOnly = true;
            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns["Description"].Width = 200;
            dataGridView1.Columns["Description"].ReadOnly = true;
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns["Price"].Width = 100;
            dataGridView1.Columns["Price"].ReadOnly = true;
            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "c";
        }


        private void txtScanBox_TextChanged(object sender, EventArgs e)
        {
            if (txtScanBox.TextLength == 9)
            {
                if (PreviousEnterCheck(txtScanBox.Text) == true)
                {
                    var d = new Decode();
                    SqlConnection cn = new SqlConnection(d.ConnectionString);
                    SqlCommand cmd = new SqlCommand("DTUSER.UnSoldItemID_Select");
                    SqlDataReader dr;
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = txtScanBox.Text.ToString();
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            while (dr.Read())
                            {
                                col1 = dr.GetValue(0).ToString();
                                col2 = dr.GetValue(1).ToString();
                                col3 = dr.GetSqlMoney(2).ToString();
                                col4 = dr.GetValue(3).ToString();
                            }
                            CheckRowInsert(col1, col2, col3, col4);
                        }
                        else
                        {
                            MessageBox.Show("No Inventory Found With that Search", "Search", MessageBoxButtons.OK);
                        }
                    }
                    catch (SqlException sx)
                    {
                        MessageBox.Show(sx.Message.ToString(), "SQL Data Error", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "C# Error", MessageBoxButtons.OK);
                    }
                    finally
                    {
                        if ( cn.State != ConnectionState.Closed)
                        {
                            cn.Close();
                        }
                    }
                }
                txtScanBox.Text = string.Empty;
            }
        }

        private void DonateItem(string ItemId)
        {
            //call the donateitem sproc for the itemnumber
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.DonateItem_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = ItemId;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString(), "SQL Data Error", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "C# Error", MessageBoxButtons.OK);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void CheckRowInsert(string col1, string col2, string col3, string col4)
        {
            if (col4 == "True")
            {
                //item is a donate = do not insert
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxDefaultButton dbb = MessageBoxDefaultButton.Button2;
                string message = "This item can be donated! Do you want to donate it?";
                string caption = "Donation Message";
                DialogResult dr;
                dr = MessageBox.Show(this, message, caption, buttons,MessageBoxIcon.Question, dbb,MessageBoxOptions.RightAlign);

                if (dr == DialogResult.Yes)
                {
                    //call the donation procedure and then give results to user
                    DonateItem(col1);
                }
                if (dr == DialogResult.No)
                {
                    //load it in the grid for processing
                    dataGridView1.Rows.Add(col1, col2, col3);
                }
            }
            else
            {
                dataGridView1.Rows.Add(col1, col2, col3);
            }
        }

        private bool PreviousEnterCheck(string ItemID)
        {
            // if this is the first one skip altogether
            if (dataGridView1.Rows.Count != 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1[0, i].Value.ToString() == ItemID.ToString())
                    {
                        return false;
                    }
                }
                return true;
            }
            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRows();
                MessageBox.Show("Returns Entered!", "Returns Data Entry", MessageBoxButtons.OK);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Fatal Error Saving Data!", "Returns Data Entry", MessageBoxButtons.OK);
            }
            finally
            {
                this.Close();
            }
        }
              
        private bool SaveRows()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ReturnItems_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = dataGridView1[0, i].Value.ToString();
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString(), "SQL Data Error", MessageBoxButtons.OK);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "C# Error", MessageBoxButtons.OK);
                return false;
            }
            finally
            {
                if ( cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            return true;
        }

        private void ReturnItems_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 50;
            dataGridView1.Height = this.Height - 200;

            cmdCancel.Location = new Point(cmdCancel.Location.X, this.Height - 100);
            cmdSave.Location = new Point(cmdSave.Location.X, this.Height - 100);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
