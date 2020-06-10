namespace SettlementFileProcess
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settlementFileDownloadScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settlementFileDownloadProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterT464ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.processToolStripMenuItem,
            this.postingToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Tools";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settlementFileDownloadScheduleToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // settlementFileDownloadScheduleToolStripMenuItem
            // 
            this.settlementFileDownloadScheduleToolStripMenuItem.Name = "settlementFileDownloadScheduleToolStripMenuItem";
            this.settlementFileDownloadScheduleToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.settlementFileDownloadScheduleToolStripMenuItem.Text = "Settlement File Download Schedule";
            this.settlementFileDownloadScheduleToolStripMenuItem.Click += new System.EventHandler(this.settlementFileDownloadScheduleToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settlementFileDownloadProcessToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // settlementFileDownloadProcessToolStripMenuItem
            // 
            this.settlementFileDownloadProcessToolStripMenuItem.Name = "settlementFileDownloadProcessToolStripMenuItem";
            this.settlementFileDownloadProcessToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.settlementFileDownloadProcessToolStripMenuItem.Text = "Settlement File Download Process";
            this.settlementFileDownloadProcessToolStripMenuItem.Click += new System.EventHandler(this.settlementFileDownloadProcessToolStripMenuItem_Click);
            // 
            // postingToolStripMenuItem
            // 
            this.postingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inboxToolStripMenuItem,
            this.processBoxToolStripMenuItem,
            this.masterT464ToolStripMenuItem});
            this.postingToolStripMenuItem.Name = "postingToolStripMenuItem";
            this.postingToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.postingToolStripMenuItem.Text = "Manual Approve";
            // 
            // inboxToolStripMenuItem
            // 
            this.inboxToolStripMenuItem.Name = "inboxToolStripMenuItem";
            this.inboxToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inboxToolStripMenuItem.Text = "Inbox";
            this.inboxToolStripMenuItem.Click += new System.EventHandler(this.inboxToolStripMenuItem_Click);
            // 
            // processBoxToolStripMenuItem
            // 
            this.processBoxToolStripMenuItem.Name = "processBoxToolStripMenuItem";
            this.processBoxToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.processBoxToolStripMenuItem.Text = "ProcessBox";
            this.processBoxToolStripMenuItem.Click += new System.EventHandler(this.processBoxToolStripMenuItem_Click);
            // 
            // masterT464ToolStripMenuItem
            // 
            this.masterT464ToolStripMenuItem.Name = "masterT464ToolStripMenuItem";
            this.masterT464ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.masterT464ToolStripMenuItem.Text = "Master T464";
            this.masterT464ToolStripMenuItem.Visible = false;
            this.masterT464ToolStripMenuItem.Click += new System.EventHandler(this.masterT464ToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settlementFileDownloadScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settlementFileDownloadProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterT464ToolStripMenuItem;

    }
}



