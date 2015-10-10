namespace DoubleTakeInventory
{
    partial class Report_DueDate
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
            this.ClothesDueDate_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ClothesDueDate_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.ClothesDueDate_SelectTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ClothesDueDate_SelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ClothesDueDate_SelectBindingSource
            // 
            this.ClothesDueDate_SelectBindingSource.DataMember = "ClothesDueDate_Select";
            this.ClothesDueDate_SelectBindingSource.DataSource = this.DoubletakeDataSet;
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
            reportDataSource1.Value = this.ClothesDueDate_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.ClothesDueDateReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(772, 499);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomPercent = 150;
            // 
            // ClothesDueDate_SelectTableAdapter
            // 
            this.ClothesDueDate_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // Report_DueDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 499);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_DueDate";
            this.Text = "Report_DueDate";
            this.Load += new System.EventHandler(this.Report_DueDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClothesDueDate_SelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ClothesDueDate_SelectBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.ClothesDueDate_SelectTableAdapter ClothesDueDate_SelectTableAdapter;
    }
}