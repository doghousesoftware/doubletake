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
    public partial class NewSales : Form
    {
        public NewSales()
        {
            InitializeComponent();
        }


        private void NewSales_Load(object sender, EventArgs e)
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
            dataGridView1.Columns.Add("SalePrice", "Sale Price");
            dataGridView1.Columns["SalePrice"].Width = 100;
            dataGridView1.Columns["SalePrice"].ReadOnly = false;
            dataGridView1.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dataGridView1.Columns["SalePrice"].DefaultCellStyle.Format = "c";

            txtScanBox.Focus();
            txtScanBox.Select();

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
                                dataGridView1.Rows.Add(dr.GetValue(0).ToString(),
                                                        dr.GetValue(1).ToString(),
                                                        dr.GetSqlMoney(2).ToString());

                            }
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
                        if (cn.State != ConnectionState.Closed)
                        {
                            cn.Close();
                        }
                    }
                }


                txtScanBox.Text = string.Empty;
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
            if (DoValidations() == true)
            {
                SaveRows();
                MessageBox.Show("Sales Entered!", "NewSales Data Entry", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Fatal Error Saving Data!", "NewSales Data Entry", MessageBoxButtons.OK);

            }


        }

        private bool DoValidations()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    decimal dcheck = decimal.Parse(dataGridView1[3, i].Value.ToString());

                }
                catch
                {
                    return false;
                }

            }
            return true;
        }

        private bool SaveRows()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ItemSold_Insert");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = dataGridView1[0, i].Value.ToString();
                    cmd.Parameters.Add("@pSalePrice", SqlDbType.Money).Value = decimal.Parse(dataGridView1[3, i].Value.ToString());
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
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            return true;
        }




        private void NewSales_Resize(object sender, EventArgs e)
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

        private void NewSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are your sure you want to close this form?", "New Sales Entry", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No || dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }

    }
}

