namespace DoubleTakeInventory
{
    partial class PrinterSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboLabel = new System.Windows.Forms.ComboBox();
            this.cboRegister = new System.Windows.Forms.ComboBox();
            this.cboReport = new System.Windows.Forms.ComboBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 66);
            this.label1.TabIndex = 3;
            this.label1.Text = "Label Printer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 66);
            this.label2.TabIndex = 4;
            this.label2.Text = "Register Printer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 61);
            this.label3.TabIndex = 5;
            this.label3.Text = "Report Printer";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(673, 435);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(91, 51);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Save and Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.80214F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.19786F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 295F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Controls.Add(this.cboLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboRegister, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboReport, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRegister, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblReport, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 98);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 212);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // cboLabel
            // 
            this.cboLabel.FormattingEnabled = true;
            this.cboLabel.Location = new System.Drawing.Point(221, 3);
            this.cboLabel.Name = "cboLabel";
            this.cboLabel.Size = new System.Drawing.Size(206, 21);
            this.cboLabel.TabIndex = 12;
            this.cboLabel.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cboRegister
            // 
            this.cboRegister.FormattingEnabled = true;
            this.cboRegister.Location = new System.Drawing.Point(221, 69);
            this.cboRegister.Name = "cboRegister";
            this.cboRegister.Size = new System.Drawing.Size(206, 21);
            this.cboRegister.TabIndex = 13;
            this.cboRegister.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cboReport
            // 
            this.cboReport.FormattingEnabled = true;
            this.cboReport.Location = new System.Drawing.Point(221, 135);
            this.cboReport.Name = "cboReport";
            this.cboReport.Size = new System.Drawing.Size(206, 21);
            this.cboReport.TabIndex = 14;
            this.cboReport.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(433, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(35, 13);
            this.lblLabel.TabIndex = 15;
            this.lblLabel.Text = "label5";
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Location = new System.Drawing.Point(433, 66);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(35, 13);
            this.lblRegister.TabIndex = 16;
            this.lblRegister.Text = "label6";
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(433, 132);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(35, 13);
            this.lblReport.TabIndex = 17;
            this.lblReport.Text = "label7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(538, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select and Set the printer for each printing activity";
            // 
            // PrinterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 498);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdClose);
            this.Name = "PrinterSettings";
            this.Text = "PrinterSettings";
            this.Load += new System.EventHandler(this.PrinterSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ComboBox cboLabel;
        private System.Windows.Forms.ComboBox cboRegister;
        private System.Windows.Forms.ComboBox cboReport;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label lblReport;
    }
}