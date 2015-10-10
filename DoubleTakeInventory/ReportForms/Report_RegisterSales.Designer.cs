namespace DoubleTakeInventory
{
    partial class Report_RegisterSales
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
            this.Invoice_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Invoice_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.Invoice_SelectTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Invoice_SelectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Invoice_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.rptInvoiceDetails.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(796, 494);
            this.reportViewer1.TabIndex = 0;
            // 
            // DoubletakeDataSet
            // 
            this.DoubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.DoubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Invoice_SelectBindingSource
            // 
            this.Invoice_SelectBindingSource.DataMember = "Invoice_Select";
            this.Invoice_SelectBindingSource.DataSource = this.DoubletakeDataSet;
            // 
            // Invoice_SelectTableAdapter
            // 
            this.Invoice_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // Report_RegisterSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 494);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_RegisterSales";
            this.Text = "Register Sales Report";
            this.Load += new System.EventHandler(this.Report_RegisterSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Invoice_SelectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Invoice_SelectBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.Invoice_SelectTableAdapter Invoice_SelectTableAdapter;
    }
}