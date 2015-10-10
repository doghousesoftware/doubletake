namespace DoubleTakeInventory
{
    partial class Report_Global
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ConsignorGlobalReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ConsignorGlobalReportTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.ConsignorGlobalReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConsignorGlobalReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsignorGlobalReportBindingSource
            // 
            this.ConsignorGlobalReportBindingSource.DataMember = "ConsignorGlobalReport";
            this.ConsignorGlobalReportBindingSource.DataSource = this.DoubletakeDataSet;
            // 
            // DoubletakeDataSet
            // 
            this.DoubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.DoubletakeDataSet.EnforceConstraints = false;
            this.DoubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.ConsignorGlobalReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.ConsignorGlobalReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(821, 511);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomPercent = 150;
            // 
            // ConsignorGlobalReportTableAdapter
            // 
            this.ConsignorGlobalReportTableAdapter.ClearBeforeFill = true;
            // 
            // Report_Global
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 511);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_Global";
            this.Text = "Report_Global";
            this.Load += new System.EventHandler(this.Report_Global_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConsignorGlobalReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ConsignorGlobalReportBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.ConsignorGlobalReportTableAdapter ConsignorGlobalReportTableAdapter;
    }
}