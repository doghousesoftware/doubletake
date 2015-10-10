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
    public partial class ArchInventory : Form
    {
        public ArchInventory()
        {
            InitializeComponent();
        }

        private void ArchInventory_Resize(object sender, EventArgs e)
        {
            dgArchive.Width = this.Width - 50;
            dgArchive.Height = this.Height - 120;
        }

        private void ArchInventory_Load(object sender, EventArgs e)
        {
            GridHeader();
        }

            enum ColumnNames
            {
                          ItemNumber,
                          ItemDescription,
                          AskingPrice,
                          DateIn,
                          Comment,
                          SoldStatus,
                          Returned,
                          InventoryCreateBy,
                          InventoryCreateDate,
                          InventoryModifiedBy,
                          InventoryModifiedDate,
                          SaleDate,
                          SaleAmount,
                          DatePaid,
                          AmountPaid,
                          SaleCreateBy,
                          SaleCreateDate,
                          SaleModifiedBy,
                          SaleModifiedDate,
                          CreateBy,
                          CreateDate
            };

        private void GridHeader()
        {
            dgArchive.Columns.Add(ColumnNames.ItemNumber.ToString(), ColumnNames.ItemNumber.ToString());
            dgArchive.Columns.Add(ColumnNames.ItemDescription.ToString(), ColumnNames.ItemDescription.ToString());
            dgArchive.Columns.Add(ColumnNames.AskingPrice.ToString(), ColumnNames.AskingPrice.ToString());
            dgArchive.Columns.Add(ColumnNames.DateIn.ToString(), ColumnNames.DateIn.ToString());
            dgArchive.Columns.Add(ColumnNames.Comment.ToString(), ColumnNames.Comment.ToString());
            dgArchive.Columns.Add(ColumnNames.SoldStatus.ToString(), ColumnNames.SoldStatus.ToString());
            dgArchive.Columns.Add(ColumnNames.Returned.ToString(), ColumnNames.Returned.ToString());
            dgArchive.Columns.Add(ColumnNames.InventoryCreateBy.ToString(), ColumnNames.InventoryCreateBy.ToString());
            dgArchive.Columns.Add(ColumnNames.InventoryCreateDate.ToString(), ColumnNames.InventoryCreateDate.ToString());
            dgArchive.Columns.Add(ColumnNames.InventoryModifiedBy.ToString(), ColumnNames.InventoryModifiedBy.ToString());
            dgArchive.Columns.Add(ColumnNames.InventoryModifiedDate.ToString(), ColumnNames.InventoryModifiedDate.ToString());
            dgArchive.Columns.Add(ColumnNames.SaleDate.ToString(), ColumnNames.SaleDate.ToString());
            dgArchive.Columns.Add(ColumnNames.SaleAmount.ToString(), ColumnNames.SaleAmount.ToString());
            dgArchive.Columns.Add(ColumnNames.DatePaid.ToString(), ColumnNames.DatePaid.ToString());
            dgArchive.Columns.Add(ColumnNames.AmountPaid.ToString(), ColumnNames.AmountPaid.ToString());
            dgArchive.Columns.Add(ColumnNames.SaleCreateBy.ToString(), ColumnNames.SaleCreateBy.ToString());
            dgArchive.Columns.Add(ColumnNames.SaleCreateDate.ToString(), ColumnNames.SaleCreateDate.ToString());
            dgArchive.Columns.Add(ColumnNames.SaleModifiedBy.ToString(), ColumnNames.SaleModifiedBy.ToString());
            dgArchive.Columns.Add(ColumnNames.SaleModifiedDate.ToString(), ColumnNames.SaleModifiedDate.ToString());
            dgArchive.Columns.Add(ColumnNames.CreateBy.ToString(), ColumnNames.CreateBy.ToString());
            dgArchive.Columns.Add(ColumnNames.CreateDate.ToString(), ColumnNames.CreateDate.ToString());
            dgArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetConsignor() == true)
            {
                GetInventory();
            }
            else
            {
                MessageBox.Show("No Consignor with that ID", "Consignor Archive Search", MessageBoxButtons.OK);
            }
        }


        private void GetInventory()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.ArchInventory_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pConsignorID", SqlDbType.Int).Value = int.Parse(textBox1.Text.ToString());
            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgArchive.Rows.Add(
                                            // ItemNumber
                                            dr.GetSqlValue(0).ToString(),
                                            // ItemDescription
                                            dr.GetSqlValue(1).ToString(),
                                            //Asking Price
                                            dr.GetSqlValue(2).ToString(),
                                            //Date In
                                            dr.GetSqlDateTime(3),
                                            //Comment
                                            dr.GetSqlValue(4).ToString(),
                                            //SoldStatus
                                            dr.GetSqlValue(5).ToString(),
                                            //Return Status
                                            dr.GetSqlValue(6).ToString(),
                                            //ICreateBy
                                            dr.GetSqlValue(7).ToString(),
                                            //ICreateDATe
                                            dr.GetSqlDateTime(8),
                                            //IModifiedBy
                                            dr.GetSqlValue(9).ToString(),
                                            //IModifiedDate
                                            dr.GetSqlDateTime(10),
                                            //SaleDAte
                                            dr.GetSqlDateTime(11),
                                            //SaleAmount
                                            dr.GetSqlValue(12).ToString(),
                                            //DatePaid
                                            dr.GetSqlDateTime(13),
                                            //AmountPaid
                                            dr.GetSqlValue(14).ToString(),
                                            //SCreateBy
                                            dr.GetSqlValue(15).ToString(),
                                            //SCreateDate
                                            dr.GetSqlDateTime(16),
                                            //SModifiedBy
                                            dr.GetSqlValue(17).ToString(),
                                            //SModifiedDate
                                            dr.GetSqlDateTime(18),
                                            //CreateBy
                                            dr.GetSqlValue(19).ToString(),
                                            //createdate
                                            dr.GetSqlDateTime(20));
                    }
                }
                else
                {
                    MessageBox.Show("No Archived Inventory Found for this Consignor", "Search", MessageBoxButtons.OK);
                    this.Close();
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

        private bool GetConsignor()
        {
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString);
            SqlCommand cmd = new SqlCommand("DTUSER.Consignor_Info");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pConsignorID", SqlDbType.VarChar).Value = int.Parse(textBox1.Text);

                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {

                    while (dr.Read())
                    {
                        lblConsignor.Text = dr.GetValue(1).ToString() + ", " + dr.GetValue(2).ToString();
                    }
                    return true;
                }
                else
                {
                    return false;
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
        }
    }   
}
