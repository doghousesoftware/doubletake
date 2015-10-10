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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //are any selections made?

            if (radioButton1.Checked != true && radioButton2.Checked != true && radioButton3.Checked != true && radioButton4.Checked != true)
            {
                MessageBox.Show("Make a selection", "Key Data Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to perform this operation?", "Key Data Change", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    ChangeSelection();
                }
                else
                {
                    MessageBox.Show("No Changes Made!", "Key Data Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ChangeSelection()
        {
            if (radioButton1.Checked == true)
            {
                //all values filled out?
                if (textBox1.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty)
                {
                    MessageBox.Show("Not all data supplied!", "Key Data Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {


                    if (UpdateInventory(int.Parse(textBox1.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text)) == true)
                    {
                        MessageSuccess();
                    }
                    else
                    {
                        MessageFailure();
                    }
                }
            }

            if (radioButton2.Checked == true)
            {
                // all values filled out?
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Not all data supplied!", "Key Data Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (RemoveConsignor(int.Parse(textBox2.Text)) == true)
                    {
                        MessageSuccess();
                    }
                    else
                    {
                        MessageFailure();
                    }
                }
            }

            if (radioButton3.Checked == true)
            {
                if (textBox5.Text == string.Empty)
                {
                    MessageBox.Show("Not all data supplied!", "Key Data Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (RemoveInventory(int.Parse(textBox5.Text)) == true)
                    {
                        MessageSuccess();

                    }
                    else
                    {
                        MessageFailure();
                    }
                }
            }

            if (radioButton4.Checked == true)
            {
                if (textBox6.Text == string.Empty)
                {
                    MessageBox.Show("Not all data supplied!", "Key Data Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (BulkArchive(int.Parse(textBox6.Text)) == true)
                    {
                        MessageSuccess();
                    }
                    else
                    {
                        MessageFailure();
                    }
                }
            }
        }

        private void MessageSuccess()
        {
            MessageBox.Show("Action Completed!", "Key Data Change", MessageBoxButtons.OK);
        }

        private void MessageFailure()
        {
            MessageBox.Show("Action Failed!","Key Data Change", MessageBoxButtons.OK);
        }


        private bool BulkArchive(int MonthValue)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.BulkArchive");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pMonthValue", SqlDbType.Int).Value = MonthValue;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                int iReturn = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
                if (iReturn == 0)
                {
                    return true;
                }
            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString());
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                cn.Close();
            }
            return true;
        }


        private bool UpdateInventory(int ItemNumber, int OldConsignor, int NewConsignor)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.Inventory_ChangeConsignor");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = ItemNumber;
            cmd.Parameters.Add("@pOldConsignorID", SqlDbType.Int).Value = OldConsignor;
            cmd.Parameters.Add("@pNewConsignorID", SqlDbType.Int).Value = NewConsignor;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                int iReturn = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
                if (iReturn == 0)
                {
                    return true;
                }
            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString());
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                cn.Close();
            }
            return true;
        }

        private bool RemoveConsignor(int ConsignorID)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.Consignor_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pConsignorID", SqlDbType.Int).Value = ConsignorID;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                int iReturn = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
                if (iReturn == 0)
                {
                    return true;
                }
            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString());
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                cn.Close();
            }

            return true;
        }


        private bool RemoveInventory(int ItemID)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ArchInventory_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = ItemID;
            SqlParameter returnValue = new SqlParameter("@Return_Value", DbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnValue);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                int iReturn = Int32.Parse(cmd.Parameters["@Return_Value"].Value.ToString());
                if (iReturn == 0)
                {
                    return true;
                }
            }
            catch (SqlException sx)
            {
                MessageBox.Show(sx.Message.ToString());
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                cn.Close();
            }

            return true;
        }


        private void AllHide()
        {
            foreach (Control mycontrol in this.Controls)
            {
                if (mycontrol is Label)
                {
                    mycontrol.Visible = false;
                }
                if (mycontrol is TextBox)
                {
                    mycontrol.Visible = false;
                    mycontrol.Text = string.Empty;
                }
            }
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            AllHide();
            label1.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = string.Empty;
            textBox3.Visible = true;
            textBox3.Text = string.Empty;
            textBox4.Visible = true;
            textBox4.Text = string.Empty;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            AllHide();
            label2.Visible = true;
            textBox2.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            AllHide();
            label5.Visible = true;
            textBox5.Visible = true;
        }


        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            AllHide();
            label6.Visible = true;
            textBox6.Visible = true;
        }
    }
}
