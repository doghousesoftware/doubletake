namespace DoubleTakeInventory.ReportQueueItems
{
    partial class InventoryStatus
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
            this.cboSoldStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdInventoryStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboSoldStatus
            // 
            this.cboSoldStatus.FormattingEnabled = true;
            this.cboSoldStatus.Location = new System.Drawing.Point(273, 51);
            this.cboSoldStatus.Name = "cboSoldStatus";
            this.cboSoldStatus.Size = new System.Drawing.Size(200, 21);
            this.cboSoldStatus.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select Status of Inventory";
            // 
            // cmdInventoryStatus
            // 
            this.cmdInventoryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInventoryStatus.Location = new System.Drawing.Point(556, 30);
            this.cmdInventoryStatus.Name = "cmdInventoryStatus";
            this.cmdInventoryStatus.Size = new System.Drawing.Size(87, 58);
            this.cmdInventoryStatus.TabIndex = 10;
            this.cmdInventoryStatus.Text = "View Report";
            this.cmdInventoryStatus.UseVisualStyleBackColor = true;
            this.cmdInventoryStatus.Click += new System.EventHandler(this.cmdInventoryStatus_Click);
            // 
            // InventoryStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cboSoldStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdInventoryStatus);
            this.Name = "InventoryStatus";
            this.Size = new System.Drawing.Size(670, 110);
            this.Load += new System.EventHandler(this.InventoryStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSoldStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdInventoryStatus;
    }
}
