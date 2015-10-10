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
    public partial class Payments : Form
    {
        int iRow;
        double PayRate;
        static bool PreSelected { get; set; }
        
        enum ConsignorCols
        {
            ConsignorID,
            LastName,
            FirstName,
            AmountDue,
        };

        enum InventoryCols
        {
            ConsignorID,
            LastName,
            FirstName,
            ItemNumber,
            ItemDescription,
            AskingPrice,
            SaleDate,
            SaleAmount,
            SoldStatus,
            PayAmount
        };

        public Payments()
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
                if (SavePayments() == false)
                {
                    MessageBox.Show("Fatal Data Error", "Payments", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Data Saved", "Payments", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Fix Errors", "Payments", MessageBoxButtons.OK);
            }
        }


        private bool SavePayments()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.Payment_Insert");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                for (int icount = 0; icount < dgThePayment.Rows.Count - 1; icount++)
                {
                    cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = int.Parse(dgThePayment[3, icount].Value.ToString());
                    cmd.Parameters.Add("@pAmountPaid", SqlDbType.Money).Value = decimal.Parse(dgThePayment[9, icount].Value.ToString());
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

        private bool DoValidations()
        {
            //Loop through the datagrid and check the dollar figures
            for (int icount = 0; icount < dgThePayment.Rows.Count - 1; icount++)
            {
                try
                {
                    decimal.Parse(dgThePayment[9, icount].Value.ToString());
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            GetPayRate();
            GlobalClass mygc = new GlobalClass();
            if (GlobalClass.ConsignerID == 0)
            {
                LoadDataGridHeader(1);
                LoadConsignor(0);
                contextMenuStrip1.Items["MarkAsPaid"].Enabled = false;
                dgThePayment.Visible = false;
                cmdCancel.Visible = false;
                cmdSave.Visible = false;
            }
            else
            {
                LoadDataGridHeader(2);
                LoadConsignor(GlobalClass.ConsignerID);
                dgThePayment.Visible = true;
                ThePaymentGridSetup();
                contextMenuStrip1.Items["GetSalesInfo"].Enabled = false;
                contextMenuStrip1.Items["GetConsignorInfo"].Enabled = false;
            }

            // set the max grid based on PreSelected
            if (!PreSelected)
            {
                dgPayments.Width = this.Width - 50;
                dgPayments.Height = this.Height - 50;
            }
            mygc.ClearEverything();
        }

        private void LoadConsignor(int ConsignorID)
        {
            string sSaleDate;
            double sSaleAmount;
            //sql code to load consignor
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ConsignorSales_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pConsignorID", SqlDbType.Int).Value = ConsignorID;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();

                if (ConsignorID == 0)
                {
                    while (dr.Read())
                    {
                        if (dr.IsDBNull(3) == true)
                        {
                            sSaleAmount = 0;
                        }
                        else
                        {
                            sSaleAmount = dr.GetSqlMoney(3).ToDouble();
                        }
                        dgPayments.Rows.Add(
                                                dr.GetSqlInt32(0).Value.ToString(),
                                                dr.GetSqlValue(1).ToString(),
                                                dr.GetSqlValue(2).ToString(),
                                                sSaleAmount.ToString("c")
                                       );
                    }
                }
                else
                {
                    while (dr.Read())
                    {
                        if (dr.IsDBNull(6) == true)
                        {
                            sSaleDate = "00/00/00";
                        }
                        else
                        {
                            sSaleDate = dr.GetDateTime(6).ToShortDateString().ToString();
                        }

                        if (dr.IsDBNull(7) == true)
                        {
                            sSaleAmount = 0;
                        }
                        else
                        {
                            sSaleAmount = dr.GetSqlMoney(7).ToDouble();
                        }

                        // BEGIN THE ROW ADD...............
                        dgPayments.Rows.Add(
                                                dr.GetSqlInt32(0).Value.ToString(),
                                                dr.GetSqlValue(1).ToString(),
                                                dr.GetSqlValue(2).ToString(),
                                                dr.GetInt32(3).ToString(),
                                                dr.GetSqlValue(4).ToString(),
                                                dr.GetSqlMoney(5).Value.ToString("c"),
                                                sSaleDate.ToString(),
                                                sSaleAmount.ToString("c"),
                                                dr.GetSqlValue(8).ToString());
                    }
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

        private void LoadDataGridHeader(int HType)
        {
            if (HType == 1)
            {
                dgPayments.Columns.Add(ConsignorCols.ConsignorID.ToString(), ConsignorCols.ConsignorID.ToString());
                dgPayments.Columns[ConsignorCols.ConsignorID.ToString()].ReadOnly = true;
                dgPayments.Columns[ConsignorCols.ConsignorID.ToString()].Width = 100;

                dgPayments.Columns.Add(ConsignorCols.LastName.ToString(), ConsignorCols.LastName.ToString());
                dgPayments.Columns[ConsignorCols.LastName.ToString()].ReadOnly = true;
                dgPayments.Columns[ConsignorCols.LastName.ToString()].Width = 150;

                dgPayments.Columns.Add(ConsignorCols.FirstName.ToString(), ConsignorCols.FirstName.ToString());
                dgPayments.Columns[ConsignorCols.FirstName.ToString()].ReadOnly = true;
                dgPayments.Columns[ConsignorCols.FirstName.ToString()].Width = 100;

                dgPayments.Columns.Add(ConsignorCols.AmountDue.ToString(), ConsignorCols.AmountDue.ToString());
                dgPayments.Columns[ConsignorCols.AmountDue.ToString()].Width = 100;
                dgPayments.Columns[ConsignorCols.AmountDue.ToString()].ReadOnly = true;
                dgPayments.Columns[ConsignorCols.AmountDue.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dgPayments.Columns[ConsignorCols.AmountDue.ToString()].DefaultCellStyle.Format = "c";
            }

            if (HType == 2)
            {
                dgPayments.Columns.Add(InventoryCols.ConsignorID.ToString(), InventoryCols.ConsignorID.ToString());
                dgPayments.Columns[InventoryCols.ConsignorID.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.ConsignorID.ToString()].ReadOnly = true;

                dgPayments.Columns.Add(InventoryCols.LastName.ToString(), InventoryCols.LastName.ToString());
                dgPayments.Columns[InventoryCols.LastName.ToString()].Width = 100;
                dgPayments.Columns[ConsignorCols.LastName.ToString()].ReadOnly = true;

                dgPayments.Columns.Add(InventoryCols.FirstName.ToString(), InventoryCols.FirstName.ToString());
                dgPayments.Columns[InventoryCols.FirstName.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.FirstName.ToString()].ReadOnly = true;

                dgPayments.Columns.Add(InventoryCols.ItemNumber.ToString(), InventoryCols.ItemNumber.ToString());
                dgPayments.Columns[InventoryCols.ItemNumber.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.ItemNumber.ToString()].ReadOnly = true;

                dgPayments.Columns.Add(InventoryCols.ItemDescription.ToString(), InventoryCols.ItemDescription.ToString());
                dgPayments.Columns[InventoryCols.ItemDescription.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.ItemDescription.ToString()].ReadOnly = true;

                dgPayments.Columns.Add(InventoryCols.AskingPrice.ToString(), InventoryCols.AskingPrice.ToString());
                dgPayments.Columns[InventoryCols.AskingPrice.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.AskingPrice.ToString()].ReadOnly = true;
                dgPayments.Columns[InventoryCols.AskingPrice.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dgPayments.Columns[InventoryCols.AskingPrice.ToString()].DefaultCellStyle.Format = "c";

                dgPayments.Columns.Add(InventoryCols.SaleDate.ToString(), InventoryCols.SaleDate.ToString());
                dgPayments.Columns[InventoryCols.SaleDate.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.SaleDate.ToString()].ReadOnly = true;

                dgPayments.Columns.Add(InventoryCols.SaleAmount.ToString(), InventoryCols.SaleAmount.ToString());
                dgPayments.Columns[InventoryCols.SaleAmount.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.SaleAmount.ToString()].ReadOnly = true;
                dgPayments.Columns[InventoryCols.SaleAmount.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dgPayments.Columns[InventoryCols.SaleAmount.ToString()].DefaultCellStyle.Format = "c";

                dgPayments.Columns.Add(InventoryCols.SoldStatus.ToString(), InventoryCols.SoldStatus.ToString());
                dgPayments.Columns[InventoryCols.SoldStatus.ToString()].Width = 100;
                dgPayments.Columns[InventoryCols.SoldStatus.ToString()].ReadOnly = true;
            }
        }

        private void GetSalesInfo_Click(object sender, EventArgs e)
        {
            if (dgPayments[0, 0].Value != null)
            {
                GlobalClass.ConsignerID = int.Parse(dgPayments[0, iRow].Value.ToString());
                Payments myp = new Payments();
                PreSelected = true;
                myp.MdiParent = this.MdiParent;
                myp.Show();
            }
        }

        private void dgPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            iRow = e.RowIndex;
        }


        private void Payments_Resize(object sender, EventArgs e)
        {
            dgPayments.Width = this.Width - 50;
            if (PreSelected)
            {
                dgThePayment.Height = this.Height - 450;
                dgThePayment.Width = this.Width - 50;

                cmdSave.Left = this.Width - 200;
                cmdSave.Top = this.Height - 100;
                
                cmdCancel.Left = this.Width - 800;
                cmdCancel.Top = this.Height - 100;

            }
            else
            {
                dgPayments.Height = this.Height - 100;
            }
        }

        private void GetConsignorInfo_Click(object sender, EventArgs e)
        {
            if (dgPayments[0,0].Value != null)
            {
                GlobalClass.ConsignerID = int.Parse(dgPayments[0, iRow].Value.ToString());

                NewConsignor mynewc = new NewConsignor();
                mynewc.MdiParent = this.MdiParent;
                mynewc.Show();
            }
            
        }

        private void ThePaymentGridSetup()
        {
            dgThePayment.Columns.Add(InventoryCols.ConsignorID.ToString(), InventoryCols.ConsignorID.ToString());
            dgThePayment.Columns[InventoryCols.ConsignorID.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.ConsignorID.ToString()].ReadOnly = true;

            dgThePayment.Columns.Add(InventoryCols.LastName.ToString(), InventoryCols.LastName.ToString());
            dgThePayment.Columns[InventoryCols.LastName.ToString()].Width = 100;
            dgThePayment.Columns[ConsignorCols.LastName.ToString()].ReadOnly = true;

            dgThePayment.Columns.Add(InventoryCols.FirstName.ToString(), InventoryCols.FirstName.ToString());
            dgThePayment.Columns[InventoryCols.FirstName.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.FirstName.ToString()].ReadOnly = true;

            dgThePayment.Columns.Add(InventoryCols.ItemNumber.ToString(), InventoryCols.ItemNumber.ToString());
            dgThePayment.Columns[InventoryCols.ItemNumber.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.ItemNumber.ToString()].ReadOnly = true;

            dgThePayment.Columns.Add(InventoryCols.ItemDescription.ToString(), InventoryCols.ItemDescription.ToString());
            dgThePayment.Columns[InventoryCols.ItemDescription.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.ItemDescription.ToString()].ReadOnly = true;

            dgThePayment.Columns.Add(InventoryCols.AskingPrice.ToString(), InventoryCols.AskingPrice.ToString());
            dgThePayment.Columns[InventoryCols.AskingPrice.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.AskingPrice.ToString()].ReadOnly = true;
            dgThePayment.Columns[InventoryCols.AskingPrice.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dgThePayment.Columns[InventoryCols.AskingPrice.ToString()].DefaultCellStyle.Format = "c";

            dgThePayment.Columns.Add(InventoryCols.SaleDate.ToString(), InventoryCols.SaleDate.ToString());
            dgThePayment.Columns[InventoryCols.SaleDate.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.SaleDate.ToString()].ReadOnly = true;

            dgThePayment.Columns.Add(InventoryCols.SaleAmount.ToString(), InventoryCols.SaleAmount.ToString());
            dgThePayment.Columns[InventoryCols.SaleAmount.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.SaleAmount.ToString()].ReadOnly = true;
            dgThePayment.Columns[InventoryCols.SaleAmount.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dgThePayment.Columns[InventoryCols.SaleAmount.ToString()].DefaultCellStyle.Format = "c";

            dgThePayment.Columns.Add(InventoryCols.SoldStatus.ToString(), InventoryCols.SoldStatus.ToString());
            dgThePayment.Columns[InventoryCols.SoldStatus.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.SoldStatus.ToString()].ReadOnly = true;

            dgThePayment.Columns.Add(InventoryCols.PayAmount.ToString(), InventoryCols.PayAmount.ToString());
            dgThePayment.Columns[InventoryCols.PayAmount.ToString()].Width = 100;
            dgThePayment.Columns[InventoryCols.PayAmount.ToString()].ReadOnly = false;
            dgThePayment.Columns[InventoryCols.PayAmount.ToString()].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dgThePayment.Columns[InventoryCols.PayAmount.ToString()].DefaultCellStyle.Format = "c";

        }


        private void MarkAsPaid_Click(object sender, EventArgs e)
        {
             
            //check to see if we are at the last row
            if (dgPayments[0, iRow].Value != null)
            {
                string sPrice = dgPayments[7, iRow].Value.ToString();
                double dPrice = double.Parse(sPrice.Replace("$", string.Empty));

                dgThePayment.Rows.Add(dgPayments[0, iRow].Value.ToString(),
                                        dgPayments[1, iRow].Value.ToString(),
                                        dgPayments[2, iRow].Value.ToString(),
                                        dgPayments[3, iRow].Value.ToString(),
                                        dgPayments[4, iRow].Value.ToString(),
                                        dgPayments[5, iRow].Value.ToString(),
                                        dgPayments[6, iRow].Value.ToString(),
                                        dgPayments[7, iRow].Value.ToString(),
                                        dgPayments[8, iRow].Value.ToString(),
                                        dPrice * (PayRate));

                dgPayments.Rows.RemoveAt(iRow);
            }
        }

        private void GetPayRate()
        {
            //sql code to load consignor
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.PayRate_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PayRate = (double.Parse(dr.GetSqlInt32(0).Value.ToString())) / 100;
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
    }
}