using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleTakeInventory.ReportQueueItems
{
    public partial class SelectedConsignorReport : UserControl
    {
        public SelectedConsignorReport()
        {
            InitializeComponent();
        }

        private void SelectedConsignorReport_Load(object sender, EventArgs e)
        {
            this.soldStatus_Select1TableAdapter.Fill(this.doubletakeDataSet.SoldStatus_Select1);
            this.consignorNameList_SelectTableAdapter.Fill(this.doubletakeDataSet.ConsignorNameList_Select, 1);
        }

        private void cmdSelectedInventory_Click(object sender, EventArgs e)
        {

            GlobalClass gc = new GlobalClass();
            gc.ClearEverything();
            GlobalClass.ConsignerID = ParseID(comboBox2.SelectedValue.ToString());
            ListBox.SelectedObjectCollection delimitedResults = listBox1.SelectedItems;
            List<string> collection = ConvertToString(listBox1.SelectedItems);
            string sqlParam = ConvertToSqlParam(collection);
            GlobalClass.WhateverString = sqlParam;

            // fire off the report
            Report_ConsignorDetailReport rpt = new Report_ConsignorDetailReport();
            Form parentForm = (Form)this.Parent.Parent.Parent.Parent;
            rpt.MdiParent = parentForm;
            rpt.Show();
        }

        /// <summary>
        /// convert the collection to sql delimited string for query
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private List<string> ConvertToString(ListBox.SelectedObjectCollection listBox)
        {
            List<string> collection = new List<string>();
            foreach (System.Data.DataRowView item in listBox)
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
        /// get the consignor id 
        /// </summary>
        /// <param name="comboboxValue"></param>
        /// <returns></returns>
        private int ParseID(string comboboxValue)
        {
            string[] separator = new string[] {"||"};
            string[] stuff = comboboxValue.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            int result = 0;
            int.TryParse(stuff[1], out result);
            return result;
        }

    }
}
