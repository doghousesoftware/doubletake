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
    public partial class PickedUpItems : Form
    {
        public PickedUpItems()
        {
            InitializeComponent();
        }

        private void PickedUpItems_Load(object sender, EventArgs e)
        {
            SetGrid();
            LoadGrid();
        }


        private void SetGrid()
        {
            cmdDonated.Columns.Add("ConsignorID", "Consignor ID");
            cmdDonated.Columns["ConsignorID"].Width = 100;
            cmdDonated.Columns["ConsignorID"].ReadOnly = true;
            cmdDonated.Columns.Add("ConsignorName", "Consignor");
            cmdDonated.Columns["ConsignorName"].Width = 200;
            cmdDonated.Columns["ConsignorName"].ReadOnly = true;
            cmdDonated.Columns.Add("ItemNumber", "Item Number");
            cmdDonated.Columns["ItemNumber"].Width = 100;
            cmdDonated.Columns["ItemNumber"].ReadOnly = true;
            cmdDonated.Columns["ItemNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            cmdDonated.Columns.Add("Description", "Description");
            cmdDonated.Columns["Description"].Width = 300;
            cmdDonated.Columns["Description"].ReadOnly = true;
            cmdDonated.Columns["Description"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            
        }

        private void LoadGrid()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ReturnItems_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();
                        
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        cmdDonated.Rows.Add(0,
                            dr.GetValue(0).ToString(),
                            dr.GetValue(1).ToString(),
                            dr.GetValue(2).ToString(),
                            dr.GetValue(3).ToString()
                            );
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
                if ( cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void PickedUpItems_Resize(object sender, EventArgs e)
        {
            cmdDonated.Width = this.Width - 50;
            cmdDonated.Height = this.Height - 160;
            button1.Location = new Point(button1.Location.X, this.Height - 100);
            button2.Location = new Point(button2.Location.X, this.Height - 100);
            button3.Location = new Point(button3.Location.X, this.Height - 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("These items will be marked as PICKED-UP.", "Pick-up and Donate Items", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                if (SaveRows(1) == true)
                {
                    MessageBox.Show("Item Status Changed to Picked-Up", "Picked-Up Item", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problem Saving Data", "Picked-Up Item", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
            {
                NoAction();
            }
        }

        private bool SaveRows(int SaveAction)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.PickedUpItems_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                cn.Open();
                cmd.Connection = cn;

               foreach (DataGridViewRow dr in cmdDonated.Rows)
               {
                    if (dr.Cells[1].Value != null)
                    {
                        if (dr.Cells[0].Value.ToString() == "1")
                        {
                            cmd.Parameters.Add("@pSaveAction", SqlDbType.Int).Value = SaveAction;
                            cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = dr.Cells[3].Value.ToString();
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                    else
                    {
                        return true;
                    }
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("These Items will be marked as DONATED.", "Pick-up and Donate Items", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                if (SaveRows(2) == true)
                {
                    MessageBox.Show("Item Status Changed to Donated", "Picked-Up Item", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problem Saving Data", "Picked-Up Item", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
            {
                NoAction();
            }

        }

        private void NoAction()
        {
            MessageBox.Show("NO action taken!", "Picked-up and Donated Items", MessageBoxButtons.OK);
        }
    }        
}