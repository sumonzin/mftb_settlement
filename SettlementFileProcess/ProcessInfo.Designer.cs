namespace SettlementFileProcess
{
    partial class ProcessInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessInfo));
            this.memberBankProcessOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.merchantProcessOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bothMerchantMemberBankSettlementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnApprove = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.ctmMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memberBankProcessOnlyToolStripMenuItem
            // 
            this.memberBankProcessOnlyToolStripMenuItem.Name = "memberBankProcessOnlyToolStripMenuItem";
            this.memberBankProcessOnlyToolStripMenuItem.Size = new System.Drawing.Size(537, 36);
            this.memberBankProcessOnlyToolStripMenuItem.Text = "Member Bank Settlement Only";
            this.memberBankProcessOnlyToolStripMenuItem.Click += new System.EventHandler(this.memberBankProcessOnlyToolStripMenuItem_Click);
            // 
            // merchantProcessOnlyToolStripMenuItem
            // 
            this.merchantProcessOnlyToolStripMenuItem.Name = "merchantProcessOnlyToolStripMenuItem";
            this.merchantProcessOnlyToolStripMenuItem.Size = new System.Drawing.Size(537, 36);
            this.merchantProcessOnlyToolStripMenuItem.Text = "Merchant Settlement Only";
            this.merchantProcessOnlyToolStripMenuItem.Click += new System.EventHandler(this.merchantProcessOnlyToolStripMenuItem_Click);
            // 
            // bothMerchantMemberBankSettlementToolStripMenuItem
            // 
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Name = "bothMerchantMemberBankSettlementToolStripMenuItem";
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Size = new System.Drawing.Size(537, 36);
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Text = "Both Merchant & Member Bank Settlement";
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Click += new System.EventHandler(this.bothMerchantMemberBankSettlementToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(537, 36);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // ctmMenu
            // 
            this.ctmMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.merchantProcessOnlyToolStripMenuItem,
            this.memberBankProcessOnlyToolStripMenuItem,
            this.bothMerchantMemberBankSettlementToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(538, 148);
            // 
            // btnApprove
            // 
            this.btnApprove.Image = global::SettlementFileProcess.Properties.Resources.Check_24x24;
            this.btnApprove.Location = new System.Drawing.Point(28, 19);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(6);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(188, 75);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Process";
            this.btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnApprove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1768, 119);
            this.panel1.TabIndex = 2;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(216, 19);
            this.btnImport.Margin = new System.Windows.Forms.Padding(6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(182, 75);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Export";
            this.btnImport.UseMnemonic = false;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ProcessInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1768, 887);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ProcessInfo";
            this.Text = "Settlement Process ";
            this.Load += new System.EventHandler(this.ProcessInfo_Load);
            this.ctmMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem memberBankProcessOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem merchantProcessOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bothMerchantMemberBankSettlementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImport;
    }
}