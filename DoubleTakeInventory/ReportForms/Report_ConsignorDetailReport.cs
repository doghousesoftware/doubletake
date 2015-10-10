using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DoubleTakeInventory.Properties;

namespace DoubleTakeInventory
{
    public partial class Report_ConsignorDetailReport : Form
    {
        private int ConsignorID { get; set; }
        public static readonly List<String> ActiveOnlyStatus = new List<String> { 
         "Needs Pricing",
         "In Stock",
         "Sold",
         "Returned",
         "Lay-Away",
         "Keep"
        };

        public Report_ConsignorDetailReport()
        {
            InitializeComponent();
            LoadActiveOnly();
        }

        private void LoadReport(int consignorID, string soldStatus)
        {
            // TODO: This line of code loads data into the 'DoubletakeDataSet.PaymentsDue_Select' table. You can move, or remove it, as needed.
            var constrg = new Decode();
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constrg.ConnectionString);
                this.ConsignorGlobalReport2_SelectedTableAdapter.Connection = con;
                this.ConsignorGlobalReport2_SelectedTableAdapter.Fill(this.doubletakeDataSet.ConsignorGlobalReport2_Selected, consignorID, soldStatus);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Data.SqlClient.SqlException sx)
            {
                string serror = string.Format("SQL Error: {0}", sx.Message);
                MessageBox.Show(serror, Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                string xerror = string.Format("Windows C# Error: {0}", ex.Message);
                MessageBox.Show(xerror, Properties.Settings.Default.MessageBoxTitle, MessageBoxButtons.OK);
            }
        }
              

        /// <summary>
        /// resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_ConsignorDetailReport_Resize(object sender, EventArgs e)
        {
            if (this.Width > 500)
            {
                reportViewer1.Width = this.Width - 50;
                reportViewer1.Height = this.Height - 100;
            }
            else
            {
                reportViewer1.Width = 720;
                reportViewer1.Height = 360;
            }
        }

        /// <summary>
        /// load up the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_ConsignorDetailReport_Load(object sender, EventArgs e)
        {
            this.soldStatus_Select1TableAdapter.Fill(this.doubletakeDataSet.SoldStatus_Select1);
            ConsignorClasses.ConsignorUtilities cu = new ConsignorClasses.ConsignorUtilities();
            ConsignorClasses.Consignor c = new ConsignorClasses.Consignor();
            c = cu.GetExistingConsignor(GlobalClass.ConsignerID);
            ConsignorID = c.ConsignorID;
            lblConsignorName.Text = string.Format("{0} {1}", c.FirstName, c.LastName);

            // check if this is coming from the right click on the search
            if (string.IsNullOrEmpty(GlobalClass.WhateverString))
            {
                listBox1.SelectedItems.Clear();
            }
            else
            {
                LoadReport(c.ConsignorID, GlobalClass.WhateverString);
            }
        }

        /// <summary>
        /// parse the selected items from the list box collection
        /// </summary>
        /// <param name="selectedItems"></param>
        /// <returns></returns>
        private List<string> ParseSelectedItems(ListBox.SelectedObjectCollection selectedItems)
        {
            List<string> collection = new List<string>();
            foreach (System.Data.DataRowView item in selectedItems)
            {
                collection.Add(item[1].ToString());
            }
            return collection;
        }

        /// <summary>
        /// convert the collection to the sql formatted paramater list
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private string ConvertToSqlParam(List<string> collection)
        {
            // pattern is this: ('Returned'),('In Stock'),('Sold-Paid'),('Sold')
            string returnParam = string.Empty;
            returnParam = "('";
            string innerLine = string.Empty;
            foreach (string item in collection)
            {
                innerLine += item;
                innerLine += "'),('";
            }
            returnParam = returnParam + innerLine;
            // now remove last 3
            returnParam = returnParam.Remove(returnParam.Length - 3, 3);
            return returnParam;
        }


        /// <summary>
        /// Navigate to the report when list box items have been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGo_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                List<string> collection = ParseSelectedItems(listBox1.SelectedItems);
                string sqlParams = ConvertToSqlParam(collection);
                ConsignorClasses.ConsignorUtilities cu = new ConsignorClasses.ConsignorUtilities();
                ConsignorClasses.Consignor c = new ConsignorClasses.Consignor();
                c = cu.GetExistingConsignor(GlobalClass.ConsignerID);
                ConsignorID = c.ConsignorID;
                LoadReport(c.ConsignorID, sqlParams);    
            }
        }

        /// <summary>
        /// load the active only to start
        /// </summary>
        private void LoadActiveOnly()
        {
            string sqlParams = ConvertToSqlParam(ActiveOnlyStatus);
            ConsignorClasses.ConsignorUtilities cu = new ConsignorClasses.ConsignorUtilities();
            ConsignorClasses.Consignor c = new ConsignorClasses.Consignor();
            c = cu.GetExistingConsignor(GlobalClass.ConsignerID);
            ConsignorID = c.ConsignorID;
            LoadReport(c.ConsignorID, sqlParams);
        }
    }
}
