namespace DoubleTakeInventory
{
    partial class Report_PaymentsDue
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
            this.PaymentsDue_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PaymentsDue_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.PaymentsDue_SelectTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsDue_SelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PaymentsDue_SelectBindingSource
            // 
            this.PaymentsDue_SelectBindingSource.DataMember = "PaymentsDue_Select";
            this.PaymentsDue_SelectBindingSource.DataSource = this.DoubletakeDataSet;
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
            reportDataSource1.Value = this.PaymentsDue_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.PaymentsDue.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(672, 496);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomPercent = 150;
            // 
            // PaymentsDue_SelectTableAdapter
            // 
            this.PaymentsDue_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // Report_PaymentsDue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 496);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_PaymentsDue";
            this.Text = "Report_PaymentsDue";
            this.Load += new System.EventHandler(this.Report_PaymentsDue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsDue_SelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PaymentsDue_SelectBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.PaymentsDue_SelectTableAdapter PaymentsDue_SelectTableAdapter;
        //private DoubletakeDataSetTableAdapters.PaymentsDueTableAdapter PaymentsDueTableAdapter;
    }
}