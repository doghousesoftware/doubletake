namespace DoubleTakeInventory.ReportQueueItems
{
    partial class SalesReport
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DateRange2 = new System.Windows.Forms.DateTimePicker();
            this.DateRange1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSalesRenge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(157, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "End Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(155, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Start Date";
            // 
            // DateRange2
            // 
            this.DateRange2.Location = new System.Drawing.Point(267, 68);
            this.DateRange2.Name = "DateRange2";
            this.DateRange2.Size = new System.Drawing.Size(200, 20);
            this.DateRange2.TabIndex = 19;
            // 
            // DateRange1
            // 
            this.DateRange1.Location = new System.Drawing.Point(267, 36);
            this.DateRange1.Name = "DateRange1";
            this.DateRange1.Size = new System.Drawing.Size(200, 20);
            this.DateRange1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sales Report (Range of Dates)";
            // 
            // cmdSalesRenge
            // 
            this.cmdSalesRenge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalesRenge.Location = new System.Drawing.Point(556, 30);
            this.cmdSalesRenge.Name = "cmdSalesRenge";
            this.cmdSalesRenge.Size = new System.Drawing.Size(87, 58);
            this.cmdSalesRenge.TabIndex = 16;
            this.cmdSalesRenge.Text = "View Report";
            this.cmdSalesRenge.UseVisualStyleBackColor = true;
            this.cmdSalesRenge.Click += new System.EventHandler(this.cmdSalesRenge_Click);
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DateRange2);
            this.Controls.Add(this.DateRange1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdSalesRenge);
            this.Name = "SalesReport";
            this.Size = new System.Drawing.Size(670, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DateRange2;
        private System.Windows.Forms.DateTimePicker DateRange1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdSalesRenge;
    }
}
