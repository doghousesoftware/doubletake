namespace DoubleTakeInventory
{
    partial class Report_InventorySelect
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
            this.Inventory_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Inventory_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.Inventory_SelectTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inventory_SelectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Inventory_SelectBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.Inventory_Select.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(683, 498);
            this.reportViewer1.TabIndex = 0;
            // 
            // DoubletakeDataSet
            // 
            this.DoubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.DoubletakeDataSet.EnforceConstraints = false;
            this.DoubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Inventory_SelectBindingSource
            // 
            this.Inventory_SelectBindingSource.DataMember = "Inventory_Select";
            this.Inventory_SelectBindingSource.DataSource = this.DoubletakeDataSet;
            this.Inventory_SelectBindingSource.CurrentChanged += new System.EventHandler(this.Inventory_SelectBindingSource_CurrentChanged);
            // 
            // Inventory_SelectTableAdapter
            // 
            this.Inventory_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // Report_InventorySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 498);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_InventorySelect";
            this.Text = "InventorySelect";
            this.Load += new System.EventHandler(this.InventorySelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DoubletakeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inventory_SelectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Inventory_SelectBindingSource;
        private DoubletakeDataSet DoubletakeDataSet;
        private DoubletakeDataSetTableAdapters.Inventory_SelectTableAdapter Inventory_SelectTableAdapter;
    }
}