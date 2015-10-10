namespace DoubleTakeInventory.ReportQueueItems
{
    partial class DaysSales
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
            this.cmdConsignorDays = new System.Windows.Forms.Button();
            this.txtConsignorID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdConsignorDays
            // 
            this.cmdConsignorDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsignorDays.Location = new System.Drawing.Point(556, 30);
            this.cmdConsignorDays.Name = "cmdConsignorDays";
            this.cmdConsignorDays.Size = new System.Drawing.Size(87, 58);
            this.cmdConsignorDays.TabIndex = 25;
            this.cmdConsignorDays.Text = "View Report";
            this.cmdConsignorDays.UseVisualStyleBackColor = true;
            this.cmdConsignorDays.Click += new System.EventHandler(this.cmdConsignorDays_Click);
            // 
            // txtConsignorID
            // 
            this.txtConsignorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsignorID.Location = new System.Drawing.Point(365, 46);
            this.txtConsignorID.Name = "txtConsignorID";
            this.txtConsignorID.Size = new System.Drawing.Size(100, 26);
            this.txtConsignorID.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(427, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Consignor number for Days Sales (or 0 (zero) for all)";
            // 
            // DaysSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmdConsignorDays);
            this.Controls.Add(this.txtConsignorID);
            this.Controls.Add(this.label9);
            this.Name = "DaysSales";
            this.Size = new System.Drawing.Size(670, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdConsignorDays;
        private System.Windows.Forms.TextBox txtConsignorID;
        private System.Windows.Forms.Label label9;
    }
}
