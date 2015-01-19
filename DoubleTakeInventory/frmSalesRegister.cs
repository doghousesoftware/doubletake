using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoubleTakeInventory;

namespace DT_SalesRegister
{
	public partial class frmSalesRegister : Form
	{
		const int HEIGHT = 480;
		const int WIDTH = 930;
		public int LineItem { get; set; } 
		public double SubTotal { get; set; }
		public double Discount { get; set; }
		public double SalesTaxes { get; set; }
		public double TotalSale { get; set; }
		public double SalesTaxRate { get; set; }
		public Register TheSale = new Register();

		public frmSalesRegister()
		{
			InitializeComponent();
			LineItem = 0;
		}

		private void FocusMe()
		{
			txtBarCodeScan.Focus();
		}

		/// <summary>
		/// this is the delete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DeleteButtonClicked(object sender, NewEventArgs e)
		{
			int li = e.LineItemID;
			UserControl1 RemoveCandidate = new UserControl1();
		  
			foreach (UserControl1 item in flowPanel.Controls)
			{
				if (item.UserControlLineItemID == li)
				{
					RemoveCandidate = item;
				}
				
			}

			flowPanel.Controls.Remove(RemoveCandidate);
			TheSale.DeleteRow(li);
			CalculateRegister();
			FocusMe();
			
		}

		/// <summary>
		/// this is for a quantity change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void TextBoxChanged(object sender, NewEventArgs e)
		{
			int li = 0;
			double di = 0;
			string TestPrice;
			string TestQuantity;
			int OriginalQuantity = TheSale.Sale[e.LineItemID].Quantity;
			double OriginalPrice = TheSale.Sale[e.LineItemID].Price;

			TestQuantity = e.QuantityChange.Replace("$", "");
			TestQuantity = TestQuantity.Replace(",", "");
			TestQuantity = TestQuantity.Replace("#", "");
			TestQuantity = TestQuantity.Replace("-", "");

			if (int.TryParse(TestQuantity, out li) == true)
			{
				li = int.Parse(TestQuantity);
			}
			else
			{
				li = OriginalQuantity;
			}

			TestPrice = e.PriceChange.Replace("$","");
			TestPrice = TestPrice.Replace(",", "");
			TestPrice = TestPrice.Replace("#", "");
			TestPrice = TestPrice.Replace("-", "");
			if (double.TryParse(TestPrice, out di) == true)
			{
				di = double.Parse(TestPrice);
			}
			else
			{
				di = OriginalPrice;
			}



			
			TheSale.Update(e.LineItemID,di,li);
			//Update the flowpanel controls with revised values
			foreach (UserControl1 item in flowPanel.Controls)
			{
				if (item.UserControlLineItemID == e.LineItemID)
				{
					item.SetNewLineItem(li, di, li * di);
				}

			}


			CalculateRegister();
			FocusMe();

		}

		
		private void Form1_Load(object sender, EventArgs e)
		{
			//make check to database
			SalesTaxCall();
			txtDiscount.Text = "$0.00";
			FocusMe();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void frmSalesRegister_Resize(object sender, EventArgs e)
		{
			
			if (this.Width != WIDTH)
			{
				this.Width = WIDTH;
			}

			if (this.Height > HEIGHT)
			{
				Point point = new Point(12, this.Height - 220);
				cmdCancel.Location = point;
				point.X = 130;
				point.Y = this.Height - 130;
				cmdSale.Location = point;
				point.X = 130;
				point.Y = this.Height - 220;
				cmdCheckSale.Location = point;
				point.X = 406;
				point.Y = this.Height - 220;
				tableLayoutPanel1.Location = point;
				flowPanel.Height = this.Height - 280;
			}
			else 
			{ 
				this.Height = HEIGHT; 
			}
		
		
		}




		private void CalculateRegister()
		{
			SubTotal = TheSale.SubTotal();
			SalesTaxes = (SubTotal + Discount) * SalesTaxRate;
			SalesTaxes = Math.Round(SalesTaxes, 2);
			TotalSale = SubTotal + Discount + SalesTaxes;
			txtSubTotal.Text = SubTotal.ToString("c");
			txtDiscount.Text = Discount.ToString("c");
			txtSalesTax.Text = SalesTaxes.ToString("c");
			txtTotalSale.Text = TotalSale.ToString("c");
			if (TotalSale > 0)
			{
				
				
				cmdSale.Enabled = true;
				cmdCheckSale.Enabled = true;
			}
			else
			{
				MessageBox.Show("Negative Sale!", "DoubleTake Sales Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cmdSale.Enabled = false;
				cmdCheckSale.Enabled = false;
			}
			
		}

		private void SalesTaxCall()
		{
			GlobalClass gc = new GlobalClass();
			SalesTaxRate = gc.SalesTax;
		}

		private void txtDiscount_TextChanged(object sender, EventArgs e)
		{
			double dResult ;
			string TestDiscount;
			TestDiscount = txtDiscount.Text.Replace("$", "");
			TestDiscount = TestDiscount.Replace("#", "");
			TestDiscount = TestDiscount.Replace("-", "");
			if (double.TryParse(TestDiscount, out dResult) == true)
			{
				dResult = double.Parse(TestDiscount)*-1;
				Discount = dResult;
				txtDiscount.Text = dResult.ToString("c");
				
			}
			else
			{
				Discount = 0;
				txtDiscount.Text = Discount.ToString("c");
				
			}
			CalculateRegister();
			FocusMe();
		}

		private bool DuplicateCheck(SoldLineItem check)
		{
			bool bReturn = false;
			foreach (SoldLineItem item in TheSale.Sale)
			{
				if (item.ItemID == check.ItemID)
				{
					if (item.ItemID == 101010101)
					{
						bReturn = false;
					}
					else
					{
						bReturn = true;
					}
				}                
			}

			return bReturn;
		}

		private void txtBarCodeScan_TextChanged(object sender, EventArgs e)
		{
			//call the barcode look up
			if (txtBarCodeScan.TextLength == 9)
			{
				
					int ScanID = 0;
					if (int.TryParse(txtBarCodeScan.Text.ToString(), out ScanID) == true)
					{
						ScanID = int.Parse(txtBarCodeScan.Text);
						SoldLineItem c = BarCodeScan(ScanID);
						if (c != null)
						{
							if (DuplicateCheck(c) == false)
							{
								TheSale.Add(c);
								UserControl1 u = new UserControl1();
								u.LoadControl(c);
								u.DeleteClick += new UserControl1.ButtonClick(DeleteButtonClicked);
								u.TextChange += new UserControl1.TextBoxChange(TextBoxChanged);
								flowPanel.Controls.Add(u);
								CalculateRegister();
								LineItem = LineItem + 1;
							}
							else
							{
								MessageBox.Show("Duplicate Scan", "DoubleTake POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}

							txtBarCodeScan.Text = string.Empty;
							FocusMe();
						}
						else
						{
							MessageBox.Show("No Scan ID Found", "DoubleTake POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
								
			}
			
		}

		

		private SoldLineItem BarCodeScan(int ItemID)
		{
			SoldLineItem returnitem = new SoldLineItem();

					SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
					SqlCommand cmd = new SqlCommand("dtuser.UnSoldItemID_Select");
					SqlDataReader dr;
					cmd.CommandType = CommandType.StoredProcedure;

					try
					{
						cn.Open();
						cmd.Connection = cn;
						cmd.Parameters.Add("@pItemID", SqlDbType.Int).Value = ItemID;

						dr = cmd.ExecuteReader();

						if (dr.HasRows == true)
						{
							while (dr.Read())
							{
								returnitem.LineItemID = LineItem;
								returnitem.ItemID = dr.GetSqlInt32(0).Value;
								returnitem.Description = dr.GetSqlValue(1).ToString();
								returnitem.Price = (double)dr.GetSqlMoney(2).Value;
								returnitem.Quantity = 1;
								returnitem.Extended = (double)dr.GetSqlMoney(2).Value;
							 }
							return returnitem;

						}
						else
						{
							MessageBox.Show("No Inventory Found With that Search", "Search", MessageBoxButtons.OK);
							return null;
						}

					}
					catch (SqlException sx)
					{
						MessageBox.Show(sx.Message.ToString(), "SQL Data Error", MessageBoxButtons.OK);
						return null;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message.ToString(), "C# Error", MessageBoxButtons.OK);
						return null;
					}
					finally
					{
						if (cn.State != ConnectionState.Closed)
						{
							cn.Close();
						}
					}
		   

		}

		private void cmdCheckSale_Click(object sender, EventArgs e)
		{
			//we only execute if there are items in the salesregister
			if (TheSale.RegisterCount() > 0)
			{
				PrintRegister printreg = new PrintRegister();
				if (printreg.PrintSale(TheSale, 1, SubTotal, Discount, SalesTaxes, TotalSale) == true)
				{
					this.Close();
				}
				else
				{
					MessageBox.Show("Writing Sale to Database failed - please note this sale!", "DoubleTake Sales Register", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}

		}

		private void cmdSale_Click(object sender, EventArgs e)
		{
			if (TheSale.RegisterCount() > 0)
			{
				PrintRegister printreg = new PrintRegister();
				if (printreg.PrintSale(TheSale, 2, SubTotal, Discount, SalesTaxes, TotalSale) == true)
				{
					this.Close();
				}
				else
				{
					MessageBox.Show("Writing Sale to Database failed - please note this sale!", "DoubleTake Sales Register", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}

			}
		}


	}


}
