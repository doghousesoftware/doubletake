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
    public partial class SearchResults : Form
    {
        public int iRowClick = -9;
        public bool DonateFlag = false;
        public SearchResults()
        {
            InitializeComponent();
        }

        private void dataGridView1_OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            iRowClick = e.RowIndex;
        }

        private void SearchResults_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 60;
        }

        private void SearchResults_Load(object sender, EventArgs e)
        {
            GlobalClass gc = new GlobalClass();
            if (GlobalClass.InventoryDescription != string.Empty)
            {
                //we have a inventory description id search
                SearchBarCodeID(GlobalClass.InventoryDescription);
                gc.ClearEverything();
                dataGridView1.ContextMenuStrip = contextMenuStrip2;
            }

            if (GlobalClass.ConsignerSearchName != string.Empty)
            {
                //we have a consignor name search
                SearchConsignerName(GlobalClass.ConsignerSearchName);
                gc.ClearEverything();
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
            }

            if (GlobalClass.ConsignerID != 0)
            {
                //we have an inventory search by consignorid 
                SearchConsignorID(GlobalClass.ConsignerID);
                gc.ClearEverything();
                dataGridView1.ContextMenuStrip = contextMenuStrip2;
            }

            gc.ClearEverything();
            statusStrip1.Text = string.Empty;
        }

        private void SearchBarCodeID(string BarCode)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ItemDescription_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pCombinedName", SqlDbType.NVarChar).Value = BarCode;

                dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    SetGridHeader(2);
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr.GetSqlInt32(0).ToString(),
                                                (int)dr.GetValue(1),
                                                dr.GetValue(2).ToString(),
                                                dr.GetValue(5).ToString(),
                                                dr.GetSqlMoney(3),
                                                dr.GetSqlDateTime(4).Value.ToString("yyyy/MM/dd")); 
                        
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

                
        private void SearchConsignerName(string CName)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ConsignorNames_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pCombinedName", SqlDbType.VarChar).Value = CName;

                dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {

                    SetGridHeader(1);
                    
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr.GetSqlInt32(0),
                                                dr.GetValue(1).ToString(),
                                                dr.GetValue(2).ToString(),
                                                dr.GetSqlMoney(3),
                                                dr.GetValue(4));
                    }
                }
                else
                {
                    MessageBox.Show("No Consignor Found With that Search", "Search", MessageBoxButtons.OK);
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

        private void SearchConsignorID(int CID)
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.GetConsignorInventory");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pConsignorID", SqlDbType.VarChar).Value = int.Parse(CID.ToString());

                dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    SetGridHeader(2);
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr.GetValue(0).ToString(),
                                                dr.GetValue(1).ToString(),
                                                dr.GetValue(2).ToString(),
                                                dr.GetValue(10).ToString(),
                                                dr.GetSqlMoney(3),
                                                dr.GetSqlDateTime(4).Value.ToString("yyyy/MM/dd"));
                                                DonateFlag = dr.GetBoolean(11);
                    }
                    if (DonateFlag == true)
                    {
                        toolStripStatusLabel1.Text = "OK to Donate Inventory for this Consignor!";
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


        private void SetGridHeader(int HType)
        {
            if (HType == 1)
            {
                dataGridView1.Columns.Add("Column00", "Consignor ID");
                dataGridView1.Columns["Column00"].Visible = true;
                dataGridView1.Columns["Column00"].Width = 100;

                dataGridView1.Columns.Add("Column01", "Last Name");
                dataGridView1.Columns["Column01"].Visible = true;
                dataGridView1.Columns["Column01"].Width = 200;

                dataGridView1.Columns.Add("Column02", "First Name");
                dataGridView1.Columns["Column02"].Visible = true;
                dataGridView1.Columns["Column02"].Width = 100;

                dataGridView1.Columns.Add("Column03", "Amount Due");
                dataGridView1.Columns["Column03"].Visible = true;
                dataGridView1.Columns["Column03"].Width = 100;
                dataGridView1.Columns["Column03"].DefaultCellStyle.Format = "$#,###.00"; 
                dataGridView1.Columns["Column03"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewCheckBoxColumn col4 = new DataGridViewCheckBoxColumn();
                col4.HeaderText = "Returns";
                dataGridView1.Columns.Add(col4);

            }

            if (HType == 2)
            {
                dataGridView1.Columns.Add("Column00", "Inventory Item");
                dataGridView1.Columns["Column00"].Visible = true;
                dataGridView1.Columns["Column00"].Width = 200;

                dataGridView1.Columns.Add("Column01", "ConsignorID");
                dataGridView1.Columns["Column01"].Visible = true;
                dataGridView1.Columns["Column01"].Width = 50;

                dataGridView1.Columns.Add("Column02", "Item Description");
                dataGridView1.Columns["Column02"].Visible = true;
                dataGridView1.Columns["Column02"].Width = 300;

                dataGridView1.Columns.Add("Column05", "Status");
                dataGridView1.Columns["Column05"].Visible = true;
                dataGridView1.Columns["Column05"].Width = 100;

                dataGridView1.Columns.Add("Column03", "Ask Price");
                dataGridView1.Columns["Column03"].Visible = true;
                dataGridView1.Columns["Column03"].Width = 100;
                dataGridView1.Columns["Column03"].DefaultCellStyle.Format = "$#,###.00";
                dataGridView1.Columns["Column03"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGridView1.Columns.Add("Column04", "Date In");
                dataGridView1.Columns["Column04"].Visible = true;
                dataGridView1.Columns["Column04"].Width = 120;
            }

            dataGridView1.ContextMenuStrip = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void updateConsignorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iRowClick != -9)
            {
                GlobalClass.ConsignerID = int.Parse(dataGridView1[0, iRowClick].Value.ToString());
                NewConsignor newForm = new NewConsignor();
                newForm.MdiParent = this.MdiParent;
                newForm.Show();
            }
            else
            {
                iRowClick = -9;
            }
        }

        private void enterNewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iRowClick != -9)
            {
                GlobalClass.ConsignerID = int.Parse(dataGridView1[0, iRowClick].Value.ToString());
                GlobalClass.ConsignerSearchName = dataGridView1[2, iRowClick].Value.ToString() + " " + dataGridView1[1, iRowClick].Value.ToString();
                NewInventory newForm = new NewInventory();
                newForm.MdiParent = this.MdiParent;
                newForm.Show();
            }
            else
            {
                iRowClick = -9;
            }
        }

        private void updateConsignorsInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iRowClick != -9)
            {
                //WE SHOW THE LIST OF INVENTORY FOR THAT CONSIGNOR
                //WHICH IS A TYPE OF ITEM SEARCH
                GlobalClass.ConsignerID = int.Parse(dataGridView1[0, iRowClick].Value.ToString());
                GlobalClass.ConsignerSearchName = string.Empty;
                GlobalClass.InventoryDescription = string.Empty;
                GlobalClass.InventoryID = string.Empty;
                
                SearchResults SR = new SearchResults();
                SR.MdiParent = this.MdiParent;
                SR.Show();
            }
            else
            {
                iRowClick = -9;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iRowClick != -9)
            {
                this.Close();
            }
            else
            {
                iRowClick = -9;
                this.Close();
            }
        }
               

        private void updateThisInventoryItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show the inventory update screen for the selected item
            if (iRowClick != -9)
            {
                GlobalClass.InventoryID = dataGridView1[0, iRowClick].Value.ToString();
                GlobalClass.ConsignerID = int.Parse(dataGridView1[1, iRowClick].Value.ToString());
               
                UpdateInventory newForm = new UpdateInventory();
                newForm.MdiParent = this.MdiParent;
                newForm.Show();
            }
            else
            {
                iRowClick = -9;
            }
        }

        private void viewConsignorOfThisItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show the consignor screen for this item
            if (iRowClick != -9)
            {
                GlobalClass.ConsignerID = int.Parse(dataGridView1[1, iRowClick].Value.ToString());
                NewConsignor newForm = new NewConsignor();
                newForm.MdiParent = this.MdiParent;
                newForm.Show();
            }
            else
            {
                iRowClick = -9;
            }
        }

        private void viewAllOfThisConsignorsInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show all inventory for this consignor 
            if (iRowClick != -9)
            {
                GlobalClass.ConsignerID = int.Parse(dataGridView1[1, iRowClick].Value.ToString());
                SearchResults newForm = new SearchResults();
                newForm.MdiParent = this.MdiParent;
                newForm.Show();
            }
            else
            {
                iRowClick = -9;
            }
            
        }

        private void reportThisConsignorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iRowClick != -9)
            {
                GlobalClass.ConsignerID = int.Parse(dataGridView1[0, iRowClick].Value.ToString());
                GlobalClass.RequestedReport = 4;
                Report_Global RG = new Report_Global();
                RG.MdiParent = this.MdiParent;
                RG.Show();
            }
        }

        
        private void reportThisConsignorByItemStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iRowClick != -9)
            {
                GlobalClass gc = new GlobalClass();
                gc.ClearEverything();
                GlobalClass.ConsignerID = int.Parse(dataGridView1[0, iRowClick].Value.ToString());
                GlobalClass.WhateverInt = -1;
                Report_ConsignorDetailReport cDetails = new Report_ConsignorDetailReport();
                cDetails.MdiParent = this.MdiParent;
                cDetails.Show();
            }
        }
    }
}
