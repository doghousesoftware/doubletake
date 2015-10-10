using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DoubleTakeInventory;
using System.IO;
using System.Xml;
using System.Deployment.Application;


namespace DoubleTakeInventory
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
            
            // set the global connection string here
            Decode d = new Decode();
            if (Properties.Settings.Default.DebugMode)
            {
                d.ConnectionString = "DoubleTakeTest";
            }
            else
            {
                d.ConnectionString = "DoubleTake";
            }
            
            dbPOS POSdb = new dbPOS();
            GlobalClass.SalesTax = POSdb.SalesTaxRate();
            if (GlobalClass.SalesTax == -100)
            {
                //failure to connect and get tax rate
                MessageBox.Show("Unable to reach SQL Database connection - please insure network connectivity exists.  System will now exit.", "NETWORK CONNECTION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            string strFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoubleTakePrinterAssignments.xml");
            if (File.Exists(strFilename) == true)
            {
                GoReader(strFilename);
            }

            string strPictureFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoubleTakePictureAssignments.xml");
            if (File.Exists(strPictureFilename) == true)
            {
                if (System.IO.File.ReadAllLines(strPictureFilename).Length != 0) 
                {
                    string[] lines = System.IO.File.ReadAllLines(strPictureFilename);
                    {
                        Image q = Image.FromFile(lines[0].ToString());
                        this.BackgroundImage = q;
                    } 
                }
            }
        }

        private void GoReader(string filename)
        {
            XmlTextReader textReader = new XmlTextReader(filename);
            textReader.Read();
            while (textReader.Read())
            {
                XmlNodeType nType = textReader.NodeType;
                switch (textReader.Name)
                {
                    case "RegisterPrinter":
                        GlobalClass.RegisterPrinter = textReader.ReadInnerXml().ToString();
                        break;

                    case "ReportPrinter":
                        GlobalClass.ReportPrinter = textReader.ReadInnerXml().ToString();
                        break;

                    case "LabelPrinter":
                        GlobalClass.LabelPrinter = textReader.ReadInnerXml().ToString();
                        break;
                }
            }
            textReader.Close();
        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

      
        private void addConsignorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewConsignor childForm = new NewConsignor();
            childForm.MdiParent = this;
            childForm.Show();
        }

        
        private void addInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInventory childForm = new NewInventory();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void updateInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInventory childForm = new UpdateInventory();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void printBarCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarCodePrinting childForm = new BarCodePrinting();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 childForm = new AboutBox1();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton2Action();
        }

        private void toolStripButton2Action()
        {
            if (toolStripTextBox1.Text != string.Empty)
            {
                int outnumber = 0;
                if (int.TryParse(toolStripTextBox1.Text, out outnumber) == true)
                {
                    GlobalClass gc = new GlobalClass();
                    gc.ClearEverything();
                    GlobalClass.ConsignerID = outnumber;
                }
                else
                {
                    //CONSIGNOR SEARCH
                    GlobalClass gc = new GlobalClass();
                    gc.ClearEverything();
                    GlobalClass.ConsignerSearchName = toolStripTextBox1.Text;
                }

                SearchResults SR = new SearchResults();
                SR.MdiParent = this;
                toolStripTextBox1.Text = string.Empty;
                SR.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1Action();
        }

        private void toolStripButton1Action()
        {
            if (toolStripTextBox2.Text != string.Empty)
            {
                //ITEM SEARCH
                GlobalClass gc = new GlobalClass();
                gc.ClearEverything();
                GlobalClass.InventoryDescription = toolStripTextBox2.Text.ToString();
                SearchResults SR = new SearchResults();
                SR.MdiParent = this;
                toolStripTextBox2.Text = string.Empty;
                SR.Show();
            }
        }

        private void enterSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSales NS = new NewSales();
            NS.MdiParent = this;
            NS.Show();
        }

        private void otherDaysSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaysSales DS = new DaysSales();
            DS.MdiParent = this;
            DS.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
           
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

       
        private void enterPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalClass.ConsignerID = 0;
            Payments DS = new Payments();
            DS.MdiParent = this;
            DS.Show();
        }

        private void performPricingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pricing PC = new Pricing();
            PC.MdiParent = this;
            PC.Show();
        }

        private void manualUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInventory UI = new UpdateInventory();
            UI.MdiParent = this;
            UI.Show();
        }


        private void reportsMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportQueue childForm = new ReportQueue();
            childForm.MdiParent = this;
            childForm.Show();
        }

        
        private void returnItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnItems childForm = new ReturnItems();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete childForm = new Delete();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.KeyPress +=new KeyPressEventHandler(keypressed1);
            toolStripTextBox2.KeyPress +=new KeyPressEventHandler(keypressed2);
        }

        private void keypressed1(Object o, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Return) | (e.KeyChar == (char)Keys.Enter))
            {
                    //looking for consignor
                    toolStripButton2Action();
            }
        }

        private void keypressed2(Object o, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Return) | (e.KeyChar == (char)Keys.Enter))
            {
                    //looking for inventory
                    toolStripButton1Action();
            }
        }

        private void consignorsArchivedInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchInventory childForm = new ArchInventory();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void pickedUpItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PickedUpItems childForm = new PickedUpItems();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void pictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoubleTakePictureAssignments.xml");
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult q = ofd.ShowDialog();
            if (q == DialogResult.OK)
            {
                System.IO.File.WriteAllText(strFilename, ofd.FileName.ToString());
                MessageBox.Show("Please close the application and restart to load your new picture", "DoubleTake", MessageBoxButtons.OK);
            }
            //check if no picture desired
            if (q == DialogResult.Cancel && ofd.FileName == string.Empty)
            {
                System.IO.File.WriteAllText(strFilename, null);
                MessageBox.Show("Please close the application and restart to remove the picture.", "DoubleTake", MessageBoxButtons.OK);
            }
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesRegister childForm = new frmSalesRegister();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void reportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegisterReportSelection childForm = new RegisterReportSelection();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void adjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterAdjustment childForm = new RegisterAdjustment();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void printerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterSettings childForm = new PrinterSettings();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void checkForSoftwareUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCheckInfo info = null;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }
    }
}