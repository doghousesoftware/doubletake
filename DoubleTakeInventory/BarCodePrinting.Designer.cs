namespace DoubleTakeInventory
{
    partial class BarCodePrinting
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
            this.BarCodePrint_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BarCodePrint_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.BarCodePrint_SelectTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodePrint_SelectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // BarCodePrint_SelectBindingSource
            // 
            this.BarCodePrint_SelectBindingSource.DataMember = "BarCodePrint_Select";
            this.BarCodePrint_SelectBindingSource.DataSource = this.DoubletakeDataSet;
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
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BarCodePrint_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.BarCodes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowContextMenu = false;
            this.reportViewer1.ShowCredentialPrompts = false;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowProgress = false;
            this.reportViewer1.ShowPromptAreaButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(630, 377);
            this.reportViewer1.TabIndex = 0;
            // 
            // BarCodePrint_SelectTableAdapter
            // 
            this.BarCodePrint_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // BarCodePrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 377);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BarCodePrinting";
            this.Text = "BarCodePrinting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarCodePrinting_FormClosing);
            this.Load += new System.EventHandler(this.BarCodePrinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BarCodePrint_SelectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BarCodePrint_SelectBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.BarCodePrint_SelectTableAdapter BarCodePrint_SelectTableAdapter;

    }
}