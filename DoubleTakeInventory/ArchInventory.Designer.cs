namespace DoubleTakeInventory
{
    partial class ArchInventory
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
            this.dgArchive = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblConsignor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgArchive)).BeginInit();
            this.SuspendLayout();
            // 
            // dgArchive
            // 
            this.dgArchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArchive.Location = new System.Drawing.Point(12, 73);
            this.dgArchive.Name = "dgArchive";
            this.dgArchive.ReadOnly = true;
            this.dgArchive.Size = new System.Drawing.Size(857, 361);
            this.dgArchive.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(134, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblConsignor
            // 
            this.lblConsignor.AutoSize = true;
            this.lblConsignor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsignor.Location = new System.Drawing.Point(280, 25);
            this.lblConsignor.Name = "lblConsignor";
            this.lblConsignor.Size = new System.Drawing.Size(25, 20);
            this.lblConsignor.TabIndex = 3;
            this.lblConsignor.Text = "    ";
            // 
            // ArchInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 471);
            this.Controls.Add(this.lblConsignor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgArchive);
            this.Name = "ArchInventory";
            this.Text = "Consignors Archived Inventory";
            this.Load += new System.EventHandler(this.ArchInventory_Load);
            this.Resize += new System.EventHandler(this.ArchInventory_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgArchive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgArchive;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblConsignor;
    }
}