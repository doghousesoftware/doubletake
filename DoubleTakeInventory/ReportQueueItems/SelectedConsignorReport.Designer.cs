namespace DoubleTakeInventory.ReportQueueItems
{
    partial class SelectedConsignorReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSelectedInventory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.soldStatusSelect1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doubletakeDataSet = new DoubleTakeInventory.DoubletakeDataSet();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.consignorNameListSelectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.soldStatus_Select1TableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.SoldStatus_Select1TableAdapter();
            this.consignorNameList_SelectTableAdapter = new DoubleTakeInventory.DoubletakeDataSetTableAdapters.ConsignorNameList_SelectTableAdapter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.soldStatusSelect1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubletakeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consignorNameListSelectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consignor Inventory Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Consignor Name";
            // 
            // cmdSelectedInventory
            // 
            this.cmdSelectedInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelectedInventory.Location = new System.Drawing.Point(556, 30);
            this.cmdSelectedInventory.Name = "cmdSelectedInventory";
            this.cmdSelectedInventory.Size = new System.Drawing.Size(87, 58);
            this.cmdSelectedInventory.TabIndex = 32;
            this.cmdSelectedInventory.Text = "View Report";
            this.cmdSelectedInventory.UseVisualStyleBackColor = true;
            this.cmdSelectedInventory.Click += new System.EventHandler(this.cmdSelectedInventory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Item Status";
            // 
            // soldStatusSelect1BindingSource
            // 
            this.soldStatusSelect1BindingSource.DataMember = "SoldStatus_Select1";
            this.soldStatusSelect1BindingSource.DataSource = this.doubletakeDataSet;
            // 
            // doubletakeDataSet
            // 
            this.doubletakeDataSet.DataSetName = "DoubletakeDataSet";
            this.doubletakeDataSet.EnforceConstraints = false;
            this.doubletakeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DataSource = this.consignorNameListSelectBindingSource;
            this.comboBox2.DisplayMember = "Column1";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(7, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(295, 21);
            this.comboBox2.TabIndex = 35;
            this.comboBox2.ValueMember = "Column1";
            // 
            // consignorNameListSelectBindingSource
            // 
            this.consignorNameListSelectBindingSource.DataMember = "ConsignorNameList_Select";
            this.consignorNameListSelectBindingSource.DataSource = this.doubletakeDataSet;
            // 
            // soldStatus_Select1TableAdapter
            // 
            this.soldStatus_Select1TableAdapter.ClearBeforeFill = true;
            // 
            // consignorNameList_SelectTableAdapter
            // 
            this.consignorNameList_SelectTableAdapter.ClearBeforeFill = true;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.soldStatusSelect1BindingSource;
            this.listBox1.DisplayMember = "SOLDSTATUS";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(375, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(151, 69);
            this.listBox1.TabIndex = 36;
            this.listBox1.ValueMember = "SOLDSTATUS";
            // 
            // SelectedConsignorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdSelectedInventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SelectedConsignorReport";
            this.Size = new System.Drawing.Size(670, 110);
            this.Load += new System.EventHandler(this.SelectedConsignorReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.soldStatusSelect1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubletakeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consignorNameListSelectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSelectedInventory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource soldStatusSelect1BindingSource;
        private DoubletakeDataSet doubletakeDataSet;
        private DoubletakeDataSetTableAdapters.SoldStatus_Select1TableAdapter soldStatus_Select1TableAdapter;
        private System.Windows.Forms.BindingSource consignorNameListSelectBindingSource;
        private DoubletakeDataSetTableAdapters.ConsignorNameList_SelectTableAdapter consignorNameList_SelectTableAdapter;
        private System.Windows.Forms.ListBox listBox1;
    }
}
