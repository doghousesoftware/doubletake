namespace DoubleTakeInventory
{
    partial class ReportQueue
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
            this.flowReportQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowReportQueue
            // 
            this.flowReportQueue.AutoScroll = true;
            this.flowReportQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowReportQueue.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowReportQueue.Location = new System.Drawing.Point(0, 0);
            this.flowReportQueue.Name = "flowReportQueue";
            this.flowReportQueue.Size = new System.Drawing.Size(677, 635);
            this.flowReportQueue.TabIndex = 4;
            this.flowReportQueue.WrapContents = false;
            // 
            // ReportQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 635);
            this.Controls.Add(this.flowReportQueue);
            this.Name = "ReportQueue";
            this.Text = "Reports Menu";
            this.Load += new System.EventHandler(this.ReportQueue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowReportQueue;

    }
}