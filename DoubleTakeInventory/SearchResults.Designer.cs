namespace DoubleTakeInventory
{
    partial class SearchResults
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateConsignorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterNewInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateConsignorsInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportThisConsignorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportThisConsignorByItemStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateThisInventoryItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConsignorOfThisItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllOfThisConsignorsInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(1, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.Height = 38;
            this.dataGridView1.Size = new System.Drawing.Size(923, 508);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_OnCellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateConsignorToolStripMenuItem,
            this.enterNewInventoryToolStripMenuItem,
            this.updateConsignorsInventoryToolStripMenuItem,
            this.reportThisConsignorToolStripMenuItem,
            this.reportThisConsignorByItemStatusToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(507, 242);
            // 
            // updateConsignorToolStripMenuItem
            // 
            this.updateConsignorToolStripMenuItem.Name = "updateConsignorToolStripMenuItem";
            this.updateConsignorToolStripMenuItem.Size = new System.Drawing.Size(506, 36);
            this.updateConsignorToolStripMenuItem.Text = "Update this Consignor";
            this.updateConsignorToolStripMenuItem.Click += new System.EventHandler(this.updateConsignorToolStripMenuItem_Click);
            // 
            // enterNewInventoryToolStripMenuItem
            // 
            this.enterNewInventoryToolStripMenuItem.Name = "enterNewInventoryToolStripMenuItem";
            this.enterNewInventoryToolStripMenuItem.Size = new System.Drawing.Size(506, 36);
            this.enterNewInventoryToolStripMenuItem.Text = "Enter New Inventory for this Consignor";
            this.enterNewInventoryToolStripMenuItem.Click += new System.EventHandler(this.enterNewInventoryToolStripMenuItem_Click);
            // 
            // updateConsignorsInventoryToolStripMenuItem
            // 
            this.updateConsignorsInventoryToolStripMenuItem.Name = "updateConsignorsInventoryToolStripMenuItem";
            this.updateConsignorsInventoryToolStripMenuItem.Size = new System.Drawing.Size(506, 36);
            this.updateConsignorsInventoryToolStripMenuItem.Text = "Update this Consignors Inventory";
            this.updateConsignorsInventoryToolStripMenuItem.Click += new System.EventHandler(this.updateConsignorsInventoryToolStripMenuItem_Click);
            // 
            // reportThisConsignorToolStripMenuItem
            // 
            this.reportThisConsignorToolStripMenuItem.Name = "reportThisConsignorToolStripMenuItem";
            this.reportThisConsignorToolStripMenuItem.Size = new System.Drawing.Size(506, 36);
            this.reportThisConsignorToolStripMenuItem.Text = "Report This Consignor";
            this.reportThisConsignorToolStripMenuItem.Click += new System.EventHandler(this.reportThisConsignorToolStripMenuItem_Click);
            // 
            // reportThisConsignorByItemStatusToolStripMenuItem
            // 
            this.reportThisConsignorByItemStatusToolStripMenuItem.Name = "reportThisConsignorByItemStatusToolStripMenuItem";
            this.reportThisConsignorByItemStatusToolStripMenuItem.Size = new System.Drawing.Size(506, 36);
            this.reportThisConsignorByItemStatusToolStripMenuItem.Text = "Report This Consignor by Item Status";
            this.reportThisConsignorByItemStatusToolStripMenuItem.Click += new System.EventHandler(this.reportThisConsignorByItemStatusToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(506, 36);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateThisInventoryItemToolStripMenuItem,
            this.viewConsignorOfThisItemToolStripMenuItem,
            this.viewAllOfThisConsignorsInventoryToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(481, 112);
            // 
            // updateThisInventoryItemToolStripMenuItem
            // 
            this.updateThisInventoryItemToolStripMenuItem.Name = "updateThisInventoryItemToolStripMenuItem";
            this.updateThisInventoryItemToolStripMenuItem.Size = new System.Drawing.Size(480, 36);
            this.updateThisInventoryItemToolStripMenuItem.Text = "Update this Inventory Item";
            this.updateThisInventoryItemToolStripMenuItem.Click += new System.EventHandler(this.updateThisInventoryItemToolStripMenuItem_Click);
            // 
            // viewConsignorOfThisItemToolStripMenuItem
            // 
            this.viewConsignorOfThisItemToolStripMenuItem.Name = "viewConsignorOfThisItemToolStripMenuItem";
            this.viewConsignorOfThisItemToolStripMenuItem.Size = new System.Drawing.Size(480, 36);
            this.viewConsignorOfThisItemToolStripMenuItem.Text = "View Consignor of this Item";
            this.viewConsignorOfThisItemToolStripMenuItem.Click += new System.EventHandler(this.viewConsignorOfThisItemToolStripMenuItem_Click);
            // 
            // viewAllOfThisConsignorsInventoryToolStripMenuItem
            // 
            this.viewAllOfThisConsignorsInventoryToolStripMenuItem.Name = "viewAllOfThisConsignorsInventoryToolStripMenuItem";
            this.viewAllOfThisConsignorsInventoryToolStripMenuItem.Size = new System.Drawing.Size(480, 36);
            this.viewAllOfThisConsignorsInventoryToolStripMenuItem.Text = "View all of this Consignors Inventory";
            this.viewAllOfThisConsignorsInventoryToolStripMenuItem.Click += new System.EventHandler(this.viewAllOfThisConsignorsInventoryToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(927, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 536);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SearchResults";
            this.Text = "SearchResults";
            this.Load += new System.EventHandler(this.SearchResults_Load);
            this.Resize += new System.EventHandler(this.SearchResults_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateConsignorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterNewInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateConsignorsInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem updateThisInventoryItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewConsignorOfThisItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllOfThisConsignorsInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportThisConsignorToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportThisConsignorByItemStatusToolStripMenuItem;
    }
}