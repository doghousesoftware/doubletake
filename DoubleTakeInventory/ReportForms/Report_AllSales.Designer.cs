namespace DoubleTakeInventory
{
    partial class Report_AllSales
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
            this.allSalesSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allSales_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.AllSales_SelectTableAdapter();
            this.AllSales_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSalesSelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllSales_SelectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.AllSales_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.AllSalesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(673, 516);
            this.reportViewer1.TabIndex = 0;
            // 
            // DoubletakeDataSet
            // 
            this.DoubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.DoubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allSalesSelectBindingSource
            // 
            this.allSalesSelectBindingSource.DataMember = "AllSales_Select";
            this.allSalesSelectBindingSource.DataSource = this.DoubletakeDataSet;
            // 
            // allSales_SelectTableAdapter
            // 
            this.allSales_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // AllSales_SelectBindingSource
            // 
            this.AllSales_SelectBindingSource.DataMember = "AllSales_Select";
            this.AllSales_SelectBindingSource.DataSource = this.DoubletakeDataSet;
            // 
            // Report_AllSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 516);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_AllSales";
            this.Text = "All Sales Report";
            this.Load += new System.EventHandler(this.Report_AllSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSalesSelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllSales_SelectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DoubletakeDataSet DoubletakeDataSet;
        private System.Windows.Forms.BindingSource allSalesSelectBindingSource;
        private DoubletakeDataSetTableAdapters.AllSales_SelectTableAdapter allSales_SelectTableAdapter;
        private System.Windows.Forms.BindingSource AllSales_SelectBindingSource;
    }
}