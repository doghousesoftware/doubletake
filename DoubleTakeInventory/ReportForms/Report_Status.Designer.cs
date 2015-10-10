namespace DoubleTakeInventory
{
    partial class Report_Status
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
            this.SoldStatus_ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SoldStatus_ReportTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.SoldStatus_ReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SoldStatus_ReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SoldStatus_ReportBindingSource
            // 
            this.SoldStatus_ReportBindingSource.DataMember = "SoldStatus_Report";
            this.SoldStatus_ReportBindingSource.DataSource = this.DoubletakeDataSet;
            // 
            // DoubletakeDataSet
            // 
            this.DoubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.DoubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SoldStatus_ReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.SoldStatusReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(758, 477);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomPercent = 150;
            // 
            // SoldStatus_ReportTableAdapter
            // 
            this.SoldStatus_ReportTableAdapter.ClearBeforeFill = true;
            // 
            // Report_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 477);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_Status";
            this.Text = "Report_Status";
            this.Load += new System.EventHandler(this.Report_Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SoldStatus_ReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SoldStatus_ReportBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.SoldStatus_ReportTableAdapter SoldStatus_ReportTableAdapter;
    }
}