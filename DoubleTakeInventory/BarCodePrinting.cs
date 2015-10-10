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
    public partial class BarCodePrinting : Form
    {
        public BarCodePrinting()
        {
            InitializeComponent();
        }

      

        private void BarCodePrinting_Load(object sender, EventArgs e)
        {
            var constrg = new Decode();
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
            this.BarCodePrint_SelectTableAdapter.Connection = con;
            this.BarCodePrint_SelectTableAdapter.Fill(this.DoubletakeDataSet.BarCodePrint_Select,0);
            this.reportViewer1.RefreshReport();
            BarCode_Print();

        }

        private void BarCode_Print()
        {
            UPCLabel.UpcLabel mylabel = new UPCLabel.UpcLabel();
            string sprice;
            var d = new Decode();
            SqlConnection cn = new SqlConnection(d.ConnectionString); 
            SqlCommand cmd = new SqlCommand("DTUSER.BarCodePrint_Select");
            SqlDataReader dr ;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pItemNumber", SqlDbType.Int).Value = 0;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();
                string PrinterName = GlobalClass.LabelPrinter;
                while (dr.Read())
                {
                    mylabel.setupc(dr.GetSqlValue(0).ToString());
                    mylabel.setupc_description(dr.GetSqlValue(2).ToString());
                    mylabel.setupc_lastline(dr.GetSqlValue(1).ToString() + " | " + dr.GetDateTime(3).ToShortDateString().ToString() + " | " );
                    sprice = "$" + decimal.Round(dr.GetSqlMoney(4).Value,2).ToString();
                    mylabel.setprice(sprice);
                    mylabel.Print(PrinterName);
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




        private void BarCodePrinting_FormClosing(Object sender, FormClosingEventArgs e)
        {
            DialogResult DR = MessageBox.Show("Did BarCodes Print OK?", "Bar Code Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DR == DialogResult.Yes)
            {
                var d = new Decode();
                SqlConnection cn = new SqlConnection(d.ConnectionString);
                SqlCommand cmd = new SqlCommand("DTUSER.WaitingToPrint_Clear");
                
                try
                {
                    cn.Open();
                    cmd.Connection = cn;
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
                    if ( cn.State != ConnectionState.Closed)
                    {
                        cn.Close();
                    }
                }

            }
            



        }



    }
}
