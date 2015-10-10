namespace DoubleTakeInventory
{
    partial class Report_ShopSales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DoubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.ShopInventory_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShopInventory_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.ShopInventory_SelectTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShopInventory_SelectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ShopInventory_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.rptShopSales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(716, 496);
            this.reportViewer1.TabIndex = 0;
            // 
            // DoubletakeDataSet
            // 
            this.DoubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.DoubletakeDataSet.EnforceConstraints = false;
            this.DoubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ShopInventory_SelectBindingSource
            // 
            this.ShopInventory_SelectBindingSource.DataMember = "ShopInventory_Select";
            this.ShopInventory_SelectBindingSource.DataSource = this.DoubletakeDataSet;
            // 
            // ShopInventory_SelectTableAdapter
            // 
            this.ShopInventory_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // Report_ShopSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 496);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_ShopSales";
            this.Text = "Shop Sales Report";
            this.Load += new System.EventHandler(this.Report_ShopSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShopInventory_SelectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ShopInventory_SelectBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.ShopInventory_SelectTableAdapter ShopInventory_SelectTableAdapter;
    }
}