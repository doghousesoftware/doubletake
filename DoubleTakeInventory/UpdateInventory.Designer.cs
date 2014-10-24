namespace DoubleTakeInventory
{
    partial class UpdateInventory
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
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cboSoldStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.txtConsignor = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAskPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ckReturn = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtConsignID = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDateIn = new System.Windows.Forms.TextBox();
            this.txtDateSold = new System.Windows.Forms.TextBox();
            this.txtDatePaid = new System.Windows.Forms.TextBox();
            this.cmdReprintBarCode = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDonateCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(539, 521);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 37);
            this.cmdSave.TabIndex = 14;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(20, 521);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 37);
            this.cmdCancel.TabIndex = 13;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cboSoldStatus
            // 
            this.cboSoldStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSoldStatus.FormattingEnabled = true;
            this.cboSoldStatus.Location = new System.Drawing.Point(149, 356);
            this.cboSoldStatus.Name = "cboSoldStatus";
            this.cboSoldStatus.Size = new System.Drawing.Size(198, 28);
            this.cboSoldStatus.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item ID";
            // 
            // txtItemID
            // 
            this.txtItemID.Enabled = false;
            this.txtItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(149, 65);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(132, 26);
            this.txtItemID.TabIndex = 2;
            // 
            // txtConsignor
            // 
            this.txtConsignor.Enabled = false;
            this.txtConsignor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsignor.Location = new System.Drawing.Point(289, 12);
            this.txtConsignor.Name = "txtConsignor";
            this.txtConsignor.Size = new System.Drawing.Size(353, 26);
            this.txtConsignor.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(149, 104);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(425, 26);
            this.txtDescription.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // txtAskPrice
            // 
            this.txtAskPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAskPrice.Location = new System.Drawing.Point(149, 144);
            this.txtAskPrice.Name = "txtAskPrice";
            this.txtAskPrice.Size = new System.Drawing.Size(198, 26);
            this.txtAskPrice.TabIndex = 5;
            this.txtAskPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ask Price";
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellPrice.Location = new System.Drawing.Point(149, 187);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(198, 26);
            this.txtSellPrice.TabIndex = 6;
            this.txtSellPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sell Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date In";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Date Sold";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Date Paid";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sold Status";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(149, 398);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(406, 91);
            this.txtComment.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Item Comment";
            // 
            // ckReturn
            // 
            this.ckReturn.AutoSize = true;
            this.ckReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckReturn.Location = new System.Drawing.Point(149, 495);
            this.ckReturn.Name = "ckReturn";
            this.ckReturn.Size = new System.Drawing.Size(77, 24);
            this.ckReturn.TabIndex = 26;
            this.ckReturn.Text = "Return";
            this.ckReturn.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "Consignor ID";
            // 
            // txtConsignID
            // 
            this.txtConsignID.Enabled = false;
            this.txtConsignID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsignID.Location = new System.Drawing.Point(149, 12);
            this.txtConsignID.Name = "txtConsignID";
            this.txtConsignID.Size = new System.Drawing.Size(127, 26);
            this.txtConsignID.TabIndex = 0;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Location = new System.Drawing.Point(305, 57);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 37);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Visible = false;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(515, 274);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(127, 26);
            this.txtPaidAmount.TabIndex = 10;
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(408, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Paid Amount";
            // 
            // txtDateIn
            // 
            this.txtDateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateIn.Location = new System.Drawing.Point(149, 229);
            this.txtDateIn.Name = "txtDateIn";
            this.txtDateIn.Size = new System.Drawing.Size(198, 26);
            this.txtDateIn.TabIndex = 7;
            this.txtDateIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDateSold
            // 
            this.txtDateSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateSold.Location = new System.Drawing.Point(149, 268);
            this.txtDateSold.Name = "txtDateSold";
            this.txtDateSold.Size = new System.Drawing.Size(198, 26);
            this.txtDateSold.TabIndex = 8;
            this.txtDateSold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDatePaid
            // 
            this.txtDatePaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatePaid.Location = new System.Drawing.Point(149, 308);
            this.txtDatePaid.Name = "txtDatePaid";
            this.txtDatePaid.Size = new System.Drawing.Size(198, 26);
            this.txtDatePaid.TabIndex = 9;
            this.txtDatePaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdReprintBarCode
            // 
            this.cmdReprintBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReprintBarCode.Location = new System.Drawing.Point(444, 57);
            this.cmdReprintBarCode.Name = "cmdReprintBarCode";
            this.cmdReprintBarCode.Size = new System.Drawing.Size(182, 37);
            this.cmdReprintBarCode.TabIndex = 35;
            this.cmdReprintBarCode.Text = "Reprint Bar Code";
            this.cmdReprintBarCode.UseVisualStyleBackColor = true;
            this.cmdReprintBarCode.Click += new System.EventHandler(this.cmdReprintBarCode_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(408, 359);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "Donate?";
            // 
            // lblDonateCheck
            // 
            this.lblDonateCheck.AutoSize = true;
            this.lblDonateCheck.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblDonateCheck.Location = new System.Drawing.Point(485, 362);
            this.lblDonateCheck.Name = "lblDonateCheck";
            this.lblDonateCheck.Size = new System.Drawing.Size(0, 17);
            this.lblDonateCheck.TabIndex = 37;
            // 
            // UpdateInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 576);
            this.Controls.Add(this.lblDonateCheck);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmdReprintBarCode);
            this.Controls.Add(this.txtDatePaid);
            this.Controls.Add(this.txtDateSold);
            this.Controls.Add(this.txtDateIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtConsignID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ckReturn);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAskPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConsignor);
            this.Controls.Add(this.txtItemID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSoldStatus);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Name = "UpdateInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateInventory";
            this.Load += new System.EventHandler(this.UpdateInventory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cboSoldStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.TextBox txtConsignor;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAskPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ckReturn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtConsignID;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDateIn;
        private System.Windows.Forms.TextBox txtDateSold;
        private System.Windows.Forms.TextBox txtDatePaid;
        private System.Windows.Forms.Button cmdReprintBarCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDonateCheck;
    }
}