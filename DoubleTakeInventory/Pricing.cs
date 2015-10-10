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
    public partial class Pricing : Form
    {
        public Pricing()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (DoValidations() == true)
            {
                if (SavePricingData() == true)
                {
                    DialogResult CheckDR = MessageBox.Show("Pricing Completed - Print Bar Codes Now?", "Pricing", MessageBoxButtons.YesNo);
                    if (CheckDR == DialogResult.Yes)
                    {
                        if (SaveWaitingToPrint() == true)
                        {
                           
                            BarCodePrinting newchild = new BarCodePrinting();
                            newchild.MdiParent = this.MdiParent;
                            newchild.Show();
                        }
                        else
                        {
                            MessageBox.Show("Fatal BarCode Save Error Happened!", "Pricing Error", MessageBoxButtons.OK);
                            this.Close();
                        }

                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Fatal Pricing Error Happened!", "Pricing Error", MessageBoxButtons.OK);
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Please correct data", "Pricing", MessageBoxButtons.OK);

            }
        }


        private bool DoValidations()
        {
            decimal iTest;
            //check row count = need at least 2 rows

            if (dgPrices.Rows.Count == 0)
            {
                return false;
            }
        
            
            for (int iCount = 0; iCount <= dgPrices.Rows.Count -1; iCount++)
            {
                try
                {
                    iTest = decimal.Parse(dgPrices["Col7", iCount].Value.ToString());
                    
                }
                catch
                {
                    return false;
                }
            }

            for (int iCount = 0; iCount <= dgPrices.Rows.Count - 1; iCount++)
            {
                iTest = decimal.Parse(dgPrices["Col7", iCount].Value.ToString());
                if (iTest == 0)
                    {
                        return false;
                    }
            }

            return true;

        }


        private bool SavePricingData()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.Pricing_Update");
            cmd.CommandType = CommandType.StoredProcedure;
            

            try
            {
                cn.Open();
                cmd.Connection = cn;

                for (int iCount = 0; iCount <= dgPrices.Rows.Count -1 ; iCount++)
                {

                    cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = int.Parse(dgPrices["Col4", iCount].Value.ToString());
                    cmd.Parameters.Add("@pAskingPrice", SqlDbType.Money).Value = decimal.Parse(dgPrices["Col7", iCount].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
                return true;

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
            
        }





        private bool SaveWaitingToPrint()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.WaitingToPrint_Clear");
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DTUSER.WaitingToPrint_Insert";

                for (int iCount = 0; iCount <= dgPrices.Rows.Count - 1; iCount++)
                {

                    cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = int.Parse(dgPrices["Col4", iCount].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
                return true;

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

        }












        private void Pricing_Load(object sender, EventArgs e)
        {
            dgPrices.Columns.Add("Col1", "Consignor ID");
            dgPrices.Columns["Col1"].ReadOnly = true;
            
            dgPrices.Columns.Add("Col2", "Last Name");
            dgPrices.Columns["Col2"].ReadOnly = true;
            
            dgPrices.Columns.Add("Col3", "First Name");
            dgPrices.Columns["Col3"].ReadOnly = true;
            
            dgPrices.Columns.Add("Col4", "Item Number");
            dgPrices.Columns["Col4"].ReadOnly = true;
            
            dgPrices.Columns.Add("Col5", "Description");
            dgPrices.Columns["Col5"].ReadOnly = true;
            
            dgPrices.Columns.Add("Col6", "Date In");
            dgPrices.Columns["Col6"].ReadOnly = true;
            
            dgPrices.Columns.Add("Col7", "Asking Price");
            dgPrices.Columns["Col7"].ReadOnly = false; 
            dgPrices.Columns["Col7"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dgPrices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgPrices.AllowUserToAddRows = false;
            dgPrices.AllowUserToDeleteRows = true;
            

            GetUnpricedItems();
        }


        private void GetUnpricedItems()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.UnPricedItem_Select");
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

                        dgPrices.Rows.Add(
                                            dr.GetSqlValue(0).ToString(),
                                            dr.GetSqlValue(1).ToString(),
                                            dr.GetSqlValue(2).ToString(),
                                            dr.GetSqlValue(3).ToString(),
                                            dr.GetSqlValue(4).ToString(),
                                            dr.GetSqlDateTime(6).Value.ToShortDateString().ToString(),
                                            dr.GetSqlMoney(5).ToString() );

                    }
                }
                else
                {
                    MessageBox.Show("No Unpriced Inventory Found ", "Search", MessageBoxButtons.OK);
                    cn.Close();
                   
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




        private void Pricing_Resize(object sender, EventArgs e)
        {
            dgPrices.Width = this.Width - 50;
            dgPrices.Height = this.Height - 120;

            cmdCancel.Location = new Point(cmdCancel.Location.X, this.Height - 100);
            cmdSave.Location = new Point(cmdSave.Location.X, this.Height - 100);
            

            
        }
    }
}
