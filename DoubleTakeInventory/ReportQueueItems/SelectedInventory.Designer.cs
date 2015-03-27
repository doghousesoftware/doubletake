namespace DoubleTakeInventory.ReportQueueItems
{
    partial class SelectedInventory
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
            this.label10 = new System.Windows.Forms.Label();
            this.cmdSelectedInventory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "Selected Inventory Report";
            // 
            // cmdSelectedInventory
            // 
            this.cmdSelectedInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelectedInventory.Location = new System.Drawing.Point(556, 30);
            this.cmdSelectedInventory.Name = "cmdSelectedInventory";
            this.cmdSelectedInventory.Size = new System.Drawing.Size(87, 58);
            this.cmdSelectedInventory.TabIndex = 31;
            this.cmdSelectedInventory.Text = "View Report";
            this.cmdSelectedInventory.UseVisualStyleBackColor = true;
            this.cmdSelectedInventory.Click += new System.EventHandler(this.cmdSelectedInventory_Click);
            // 
            // SelectedInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdSelectedInventory);
            this.Name = "SelectedInventory";
            this.Size = new System.Drawing.Size(670, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdSelectedInventory;
    }
}
