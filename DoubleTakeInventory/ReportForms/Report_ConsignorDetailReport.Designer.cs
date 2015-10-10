namespace DoubleTakeInventory
{
    partial class Report_ConsignorDetailReport
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
            this.ConsignorGlobalReport2_SelectedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.soldStatusSelect1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doubletakeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblConsignorName = new System.Windows.Forms.Label();
            this.soldStatus_Select1TableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.SoldStatus_Select1TableAdapter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.BarCodePrint_SelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BarCodePrint_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.BarCodePrint_SelectTableAdapter();
            this.ConsignorGlobalReport2_SelectedTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.ConsignorGlobalReport2_SelectedTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConsignorGlobalReport2_SelectedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubletakeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soldStatusSelect1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubletakeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodePrint_SelectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsignorGlobalReport2_SelectedBindingSource
            // 
            this.ConsignorGlobalReport2_SelectedBindingSource.DataMember = "ConsignorGlobalReport2_Selected";
            this.ConsignorGlobalReport2_SelectedBindingSource.DataSource = this.doubletakeDataSet;
            // 
            // doubletakeDataSet
            // 
            this.doubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.doubletakeDataSet.EnforceConstraints = false;
            this.doubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ConsignorGlobalReport2_SelectedBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DoubleTakeInventory.ReportDefinitions.ConsignorGlobalReport_Selected.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 64);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(720, 342);
            this.reportViewer1.TabIndex = 0;
            // 
            // soldStatusSelect1BindingSource
            // 
            this.soldStatusSelect1BindingSource.DataMember = "SoldStatus_Select1";
            this.soldStatusSelect1BindingSource.DataSource = this.doubletakeDataSetBindingSource;
            // 
            // doubletakeDataSetBindingSource
            // 
            this.doubletakeDataSetBindingSource.DataSource = this.doubletakeDataSet;
            this.doubletakeDataSetBindingSource.Position = 0;
            // 
            // lblConsignorName
            // 
            this.lblConsignorName.AutoSize = true;
            this.lblConsignorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignorName.Location = new System.Drawing.Point(12, 15);
            this.lblConsignorName.Name = "lblConsignorName";
            this.lblConsignorName.Size = new System.Drawing.Size(57, 20);
            this.lblConsignorName.TabIndex = 3;
            this.lblConsignorName.Text = "label2";
            // 
            // soldStatus_Select1TableAdapter
            // 
            this.soldStatus_Select1TableAdapter.ClearBeforeFill = true;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.soldStatusSelect1BindingSource;
            this.listBox1.DisplayMember = "SOLDSTATUS";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(388, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(120, 43);
            this.listBox1.TabIndex = 4;
            this.listBox1.ValueMember = "SOLDSTATUS";
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(514, 20);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(76, 34);
            this.cmdGo.TabIndex = 5;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // BarCodePrint_SelectBindingSource
            // 
            this.BarCodePrint_SelectBindingSource.DataMember = "BarCodePrint_Select";
            this.BarCodePrint_SelectBindingSource.DataSource = this.doubletakeDataSet;
            // 
            // BarCodePrint_SelectTableAdapter
            // 
            this.BarCodePrint_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // ConsignorGlobalReport2_SelectedTableAdapter
            // 
            this.ConsignorGlobalReport2_SelectedTableAdapter.ClearBeforeFill = true;
            // 
            // Report_ConsignorDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 417);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblConsignorName);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_ConsignorDetailReport";
            this.Text = "ConsignorDetailReport";
            this.Load += new System.EventHandler(this.Report_ConsignorDetailReport_Load);
            this.Resize += new System.EventHandler(this.Report_ConsignorDetailReport_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ConsignorGlobalReport2_SelectedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubletakeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soldStatusSelect1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubletakeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodePrint_SelectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblConsignorName;
        private DoubletakeDataSet doubletakeDataSet;
        private System.Windows.Forms.BindingSource doubletakeDataSetBindingSource;
        private System.Windows.Forms.BindingSource soldStatusSelect1BindingSource;
        private DoubletakeDataSetTableAdapters.SoldStatus_Select1TableAdapter soldStatus_Select1TableAdapter;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button cmdGo;
        private System.Windows.Forms.BindingSource BarCodePrint_SelectBindingSource;
        private DoubletakeDataSetTableAdapters.BarCodePrint_SelectTableAdapter BarCodePrint_SelectTableAdapter;
        private System.Windows.Forms.BindingSource ConsignorGlobalReport2_SelectedBindingSource;
        private DoubletakeDataSetTableAdapters.ConsignorGlobalReport2_SelectedTableAdapter ConsignorGlobalReport2_SelectedTableAdapter;
    }
}