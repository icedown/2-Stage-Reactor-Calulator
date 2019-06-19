namespace _2StageCalculator
{
    partial class ReactorReportForm
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
            this.WBReport = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WBReport
            // 
            this.WBReport.AllowNavigation = false;
            this.WBReport.AllowWebBrowserDrop = false;
            this.WBReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WBReport.IsWebBrowserContextMenuEnabled = false;
            this.WBReport.Location = new System.Drawing.Point(0, 0);
            this.WBReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBReport.Name = "WBReport";
            this.WBReport.Size = new System.Drawing.Size(800, 450);
            this.WBReport.TabIndex = 0;
            this.WBReport.WebBrowserShortcutsEnabled = false;
            // 
            // ReactorReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WBReport);
            this.Name = "ReactorReportForm";
            this.Text = "Reactor Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WBReport;
    }
}