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
    public partial class NewConsignor : Form
    {
        public NewConsignor()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //Save
            if (txtConsignorID.Text == string.Empty)
            {
                if ((txtLastName.Text != string.Empty) & (txtFirstName.Text != string.Empty))
                {
                    NewConsignorInsert();
                    DialogResult dr = MessageBox.Show("Enter New Inventory for this Consignor?", "New Consignor", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        //spawn the enter new inventory form
                        GlobalClass.ConsignerID = int.Parse(txtConsignorID.Text.ToString());
                        GlobalClass.ConsignerSearchName = txtFirstName.Text + " " + txtLastName.Text;

                        NewInventory newForm = new NewInventory();
                        newForm.MdiParent = this.MdiParent;
                        newForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Incomplete data entered", "New Consignor", MessageBoxButtons.OK);
                }
            }
            else
            {
                bool result = ConsignorUpdate();
                if (result)
                {
                    MessageBox.Show("Data Saved", "Consignor Data", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Data was not Saved - there was an issue", "Consignor Data", MessageBoxButtons.OK);
                }    
            }
                ClearConsignor();
        }


        private void NewConsignorInsert()
        {
            int count;
            ConsignorClasses.ConsignorUtilities cu = new ConsignorClasses.ConsignorUtilities();
            ConsignorClasses.Consignor c = new ConsignorClasses.Consignor();
            c.LastName = txtLastName.Text;
            c.FirstName = txtFirstName.Text;
            c.Address1Street = txtAddress.Text;
            c.Address1City = txtCity.Text;
            c.Address1State = txtState.Text;
            c.Address1Zip = txtZipCode.Text;
            c.HomePhone = txtHomePhone.Text;
            c.WorkPhone = txtWorkPhone.Text;
            c.CellPhone = txtCellPhone.Text;
            c.EmailAddress = txtemail.Text;
            c.Comments = txtComments.Text;
            c.Donate = ckDonate.Checked;
            c.CreateBy = "NewConsignor";

            count = cu.AddNewConsignor(c);

            switch (count)
            {
                case -1:
                    MessageBox.Show("There was a SQL Data Error", Properties.Settings.Default.MessageBoxTitle,  MessageBoxButtons.OK);
                    break;
                case -2:
                    MessageBox.Show("C# Error", Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
                    break;
                default:
                    txtConsignorID.Visible = true;
                    txtConsignorID.Text = count.ToString();
                    txtConsignorID.Enabled = false;
                    ClearConsignor();
                    break;
            }
        }


        private bool ConsignorUpdate()
        {
            ConsignorClasses.Consignor c = new ConsignorClasses.Consignor();
            ConsignorClasses.ConsignorUtilities cu = new ConsignorClasses.ConsignorUtilities();

            // set the updated consignor
            c.Address1City = txtCity.Text;
            c.Address1State = txtState.Text;
            c.Address1Street = txtAddress.Text;
            c.Address1Zip = txtZipCode.Text;
            c.CellPhone = txtCellPhone.Text;
            c.Comments = txtComments.Text;
            c.ConsignorID = int.Parse(txtConsignorID.Text);
            c.Donate = ckDonate.Checked;
            c.EmailAddress = txtemail.Text;
            c.FirstName = txtFirstName.Text;
            c.HomePhone = txtHomePhone.Text;
            c.LastName = txtLastName.Text;
            c.WorkPhone = txtWorkPhone.Text;
            
            // update the consignor
            bool result = cu.Consignor_Update(c);
            ClearConsignor();
            return result;
        }



        private void NewConsignor_Load(object sender, EventArgs e)
        {
            GlobalClass gc = new GlobalClass();
            if (GlobalClass.ConsignerID != 0)
            {
                //we have a consigner to update
                lblConsignorID.Visible = true;
                txtConsignorID.Visible = true;
                GetConsignor(GlobalClass.ConsignerID);
            }
            else
            {
                lblConsignorID.Visible = false;
                txtConsignorID.Visible = false;
                //allow new consignor to be entered
            }
            gc.ClearEverything();
        }
        
        private void GetConsignor(int ConsignorID)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DoubleTake"].ToString());
            SqlCommand cmd = new SqlCommand("DTUSER.GetConsignor_Select");
            SqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.Parameters.Add("@pConsignorID", SqlDbType.VarChar).Value = ConsignorID;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtConsignorID.Text = ConsignorID.ToString();
                    txtLastName.Text = dr.GetValue(0).ToString();
                    txtFirstName.Text = dr.GetValue(1).ToString();
                    txtAddress.Text = dr.GetValue(2).ToString();
                    txtCity.Text = dr.GetValue(3).ToString();
                    txtState.Text = dr.GetValue(4).ToString();
                    txtZipCode.Text = dr.GetValue(5).ToString();
                    txtHomePhone.Text = dr.GetValue(6).ToString();
                    txtWorkPhone.Text = dr.GetValue(7).ToString();
                    txtCellPhone.Text = dr.GetValue(8).ToString();
                    txtemail.Text = dr.GetValue(9).ToString();
                    txtComments.Text = dr.GetValue(10).ToString();
                    ckDonate.Checked = dr.GetBoolean(11);

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
            //now clear the consignor
            ClearConsignor();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearConsignor()
        {
            //now clear the consignor
            GlobalClass.ConsignerID = 0;
        }
         
    }
}
