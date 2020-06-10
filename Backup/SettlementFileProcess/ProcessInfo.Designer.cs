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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gpbFilter = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rdoMerchantCode = new System.Windows.Forms.RadioButton();
            this.dgvSettlementLog = new System.Windows.Forms.DataGridView();
            this.Approve = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPUDfCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutgoingAmountSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutgoingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutgoingFeeSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutgoingFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncomingAmountSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncomingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncomingFeeSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncomingFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSTMAmtSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSTMAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STFAmountSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STFAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STFFeeSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STFFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutgoingSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncomingSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettlementCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantSTMAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservedForUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STFDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.ctmMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gpbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlementLog)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // memberBankProcessOnlyToolStripMenuItem
            // 
            this.memberBankProcessOnlyToolStripMenuItem.Name = "memberBankProcessOnlyToolStripMenuItem";
            this.memberBankProcessOnlyToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.memberBankProcessOnlyToolStripMenuItem.Text = "Member Bank Settlement Only";
            this.memberBankProcessOnlyToolStripMenuItem.Click += new System.EventHandler(this.memberBankProcessOnlyToolStripMenuItem_Click);
            // 
            // merchantProcessOnlyToolStripMenuItem
            // 
            this.merchantProcessOnlyToolStripMenuItem.Name = "merchantProcessOnlyToolStripMenuItem";
            this.merchantProcessOnlyToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.merchantProcessOnlyToolStripMenuItem.Text = "Merchant Settlement Only";
            this.merchantProcessOnlyToolStripMenuItem.Click += new System.EventHandler(this.merchantProcessOnlyToolStripMenuItem_Click);
            // 
            // bothMerchantMemberBankSettlementToolStripMenuItem
            // 
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Name = "bothMerchantMemberBankSettlementToolStripMenuItem";
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Text = "Both Merchant & Member Bank Settlement";
            this.bothMerchantMemberBankSettlementToolStripMenuItem.Click += new System.EventHandler(this.bothMerchantMemberBankSettlementToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.merchantProcessOnlyToolStripMenuItem,
            this.memberBankProcessOnlyToolStripMenuItem,
            this.bothMerchantMemberBankSettlementToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(270, 92);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gpbFilter);
            this.panel2.Controls.Add(this.dgvSettlementLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 399);
            this.panel2.TabIndex = 3;
            // 
            // gpbFilter
            // 
            this.gpbFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbFilter.Controls.Add(this.radioButton2);
            this.gpbFilter.Controls.Add(this.rdoMerchantCode);
            this.gpbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbFilter.Location = new System.Drawing.Point(271, 120);
            this.gpbFilter.Name = "gpbFilter";
            this.gpbFilter.Size = new System.Drawing.Size(342, 158);
            this.gpbFilter.TabIndex = 1;
            this.gpbFilter.TabStop = false;
            this.gpbFilter.Text = "Filter Information";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(190, 73);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(115, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Member Code";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.rdo_Click);
            // 
            // rdoMerchantCode
            // 
            this.rdoMerchantCode.AutoSize = true;
            this.rdoMerchantCode.Location = new System.Drawing.Point(49, 73);
            this.rdoMerchantCode.Name = "rdoMerchantCode";
            this.rdoMerchantCode.Size = new System.Drawing.Size(122, 19);
            this.rdoMerchantCode.TabIndex = 0;
            this.rdoMerchantCode.TabStop = true;
            this.rdoMerchantCode.Text = "Merchant Code";
            this.rdoMerchantCode.UseVisualStyleBackColor = true;
            this.rdoMerchantCode.Click += new System.EventHandler(this.rdo_Click);
            // 
            // dgvSettlementLog
            // 
            this.dgvSettlementLog.AllowUserToAddRows = false;
            this.dgvSettlementLog.AllowUserToDeleteRows = false;
            this.dgvSettlementLog.AllowUserToOrderColumns = true;
            this.dgvSettlementLog.AllowUserToResizeRows = false;
            this.dgvSettlementLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettlementLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Approve,
            this.Status,
            this.MPUDfCode,
            this.MerchantCode,
            this.OutgoingAmountSign,
            this.OutgoingAmount,
            this.OutgoingFeeSign,
            this.OutgoingFee,
            this.IncomingAmountSign,
            this.IncomingAmount,
            this.IncomingFeeSign,
            this.IncomingFee,
            this.TotalSTMAmtSign,
            this.TotalSTMAmt,
            this.STFAmountSign,
            this.STFAmount,
            this.STFFeeSign,
            this.STFFee,
            this.OutgoingSummary,
            this.IncomingSummary,
            this.SettlementCurrency,
            this.MerchantSTMAc,
            this.ReservedForUse,
            this.FileType,
            this.STFDate});
            this.dgvSettlementLog.ContextMenuStrip = this.ctmMenu;
            this.dgvSettlementLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSettlementLog.Location = new System.Drawing.Point(0, 0);
            this.dgvSettlementLog.Name = "dgvSettlementLog";
            this.dgvSettlementLog.Size = new System.Drawing.Size(884, 399);
            this.dgvSettlementLog.TabIndex = 0;
            // 
            // Approve
            // 
            this.Approve.FalseValue = "0";
            this.Approve.HeaderText = "";
            this.Approve.Name = "Approve";
            this.Approve.TrueValue = "1";
            this.Approve.Width = 30;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // MPUDfCode
            // 
            this.MPUDfCode.DataPropertyName = "MPUDFCODE";
            this.MPUDfCode.HeaderText = "Member Institution Code";
            this.MPUDfCode.Name = "MPUDfCode";
            // 
            // MerchantCode
            // 
            this.MerchantCode.DataPropertyName = "MerchantCode";
            this.MerchantCode.HeaderText = "Merchant Code";
            this.MerchantCode.Name = "MerchantCode";
            // 
            // OutgoingAmountSign
            // 
            this.OutgoingAmountSign.DataPropertyName = "OUTGOINGAMOUTSIGN";
            this.OutgoingAmountSign.HeaderText = "Outgoing Amount Sign";
            this.OutgoingAmountSign.Name = "OutgoingAmountSign";
            // 
            // OutgoingAmount
            // 
            this.OutgoingAmount.DataPropertyName = "OUTGOINGAMOUNT";
            this.OutgoingAmount.HeaderText = "Outgoing Amount";
            this.OutgoingAmount.Name = "OutgoingAmount";
            // 
            // OutgoingFeeSign
            // 
            this.OutgoingFeeSign.DataPropertyName = "OUTGOINGFEESIGN";
            this.OutgoingFeeSign.HeaderText = "Outgoing Fee Sign";
            this.OutgoingFeeSign.Name = "OutgoingFeeSign";
            // 
            // OutgoingFee
            // 
            this.OutgoingFee.DataPropertyName = "OUTGOINGFEE";
            this.OutgoingFee.HeaderText = "Outgoing Fee";
            this.OutgoingFee.Name = "OutgoingFee";
            // 
            // IncomingAmountSign
            // 
            this.IncomingAmountSign.DataPropertyName = "INCOMINGAMOUNTSIGN";
            this.IncomingAmountSign.HeaderText = "Incoming Amoung Sign";
            this.IncomingAmountSign.Name = "IncomingAmountSign";
            // 
            // IncomingAmount
            // 
            this.IncomingAmount.DataPropertyName = "INCOMINGAMOUNT";
            this.IncomingAmount.HeaderText = "Incoming Amount";
            this.IncomingAmount.Name = "IncomingAmount";
            // 
            // IncomingFeeSign
            // 
            this.IncomingFeeSign.DataPropertyName = "INCOMINGFEESIGN";
            this.IncomingFeeSign.HeaderText = "Incoming Fee Sign";
            this.IncomingFeeSign.Name = "IncomingFeeSign";
            // 
            // IncomingFee
            // 
            this.IncomingFee.DataPropertyName = "INCOMINGFEE";
            this.IncomingFee.HeaderText = "Incoming Fee";
            this.IncomingFee.Name = "IncomingFee";
            // 
            // TotalSTMAmtSign
            // 
            this.TotalSTMAmtSign.DataPropertyName = "TotalSettlementAmtSign";
            this.TotalSTMAmtSign.HeaderText = "Total Settlement Amount Sign";
            this.TotalSTMAmtSign.Name = "TotalSTMAmtSign";
            // 
            // TotalSTMAmt
            // 
            this.TotalSTMAmt.DataPropertyName = "TotalSettlementAmt";
            this.TotalSTMAmt.HeaderText = "Total Settlement Amount";
            this.TotalSTMAmt.Name = "TotalSTMAmt";
            // 
            // STFAmountSign
            // 
            this.STFAmountSign.DataPropertyName = "STFAMOUNTSIGN";
            this.STFAmountSign.HeaderText = "Settlement Amount Sign";
            this.STFAmountSign.Name = "STFAmountSign";
            // 
            // STFAmount
            // 
            this.STFAmount.DataPropertyName = "STFAMOUNT";
            this.STFAmount.HeaderText = "Settlement File Amount";
            this.STFAmount.Name = "STFAmount";
            // 
            // STFFeeSign
            // 
            this.STFFeeSign.DataPropertyName = "STFFEESIGN";
            this.STFFeeSign.HeaderText = "Settlement File Fee Sign";
            this.STFFeeSign.Name = "STFFeeSign";
            // 
            // STFFee
            // 
            this.STFFee.DataPropertyName = "STFFEE";
            this.STFFee.HeaderText = "Settlement File Fee";
            this.STFFee.Name = "STFFee";
            // 
            // OutgoingSummary
            // 
            this.OutgoingSummary.DataPropertyName = "OUTGOINGSUMMARY";
            this.OutgoingSummary.HeaderText = "Outgoing Summary";
            this.OutgoingSummary.Name = "OutgoingSummary";
            // 
            // IncomingSummary
            // 
            this.IncomingSummary.DataPropertyName = "INCOMINGSUMMARY";
            this.IncomingSummary.HeaderText = "Incoming Summary";
            this.IncomingSummary.Name = "IncomingSummary";
            // 
            // SettlementCurrency
            // 
            this.SettlementCurrency.DataPropertyName = "SETTLEMENTCURRENCY";
            this.SettlementCurrency.HeaderText = "Settlement Currency";
            this.SettlementCurrency.Name = "SettlementCurrency";
            // 
            // MerchantSTMAc
            // 
            this.MerchantSTMAc.DataPropertyName = "MerchantSettlementAccount";
            this.MerchantSTMAc.HeaderText = "Merchant Settlement Account";
            this.MerchantSTMAc.Name = "MerchantSTMAc";
            // 
            // ReservedForUse
            // 
            this.ReservedForUse.DataPropertyName = "RESERVED";
            this.ReservedForUse.HeaderText = "Reserved For Use";
            this.ReservedForUse.Name = "ReservedForUse";
            // 
            // FileType
            // 
            this.FileType.DataPropertyName = "FILETYPE";
            this.FileType.HeaderText = "File Type";
            this.FileType.Name = "FileType";
            // 
            // STFDate
            // 
            this.STFDate.DataPropertyName = "SettlementDate";
            this.STFDate.HeaderText = "SettlementDate";
            this.STFDate.Name = "STFDate";
            // 
            // btnApprove
            // 
            this.btnApprove.Image = global::SettlementFileProcess.Properties.Resources.Check_24x24;
            this.btnApprove.Location = new System.Drawing.Point(98, 10);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(94, 39);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Process";
            this.btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Image = global::SettlementFileProcess.Properties.Resources.Cancel_24x24;
            this.btnReject.Location = new System.Drawing.Point(192, 10);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(94, 39);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Reject";
            this.btnReject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::SettlementFileProcess.Properties.Resources.Search_16x16;
            this.btnSearch.Location = new System.Drawing.Point(852, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 24);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.btnReject);
            this.panel1.Controls.Add(this.btnApprove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 62);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkCheckAll);
            this.panel3.Location = new System.Drawing.Point(3, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(94, 39);
            this.panel3.TabIndex = 6;
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(7, 11);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(71, 17);
            this.chkCheckAll.TabIndex = 0;
            this.chkCheckAll.Text = "Check All";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(628, 20);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(218, 20);
            this.txtFilter.TabIndex = 2;
            // 
            // ProcessInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessInfo";
            this.Text = "Settlement Process ";
            this.Load += new System.EventHandler(this.ProcessInfo_Load);
            this.ctmMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gpbFilter.ResumeLayout(false);
            this.gpbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlementLog)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem memberBankProcessOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem merchantProcessOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bothMerchantMemberBankSettlementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gpbFilter;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rdoMerchantCode;
        private System.Windows.Forms.DataGridView dgvSettlementLog;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Approve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPUDfCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutgoingAmountSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutgoingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutgoingFeeSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutgoingFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncomingAmountSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncomingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncomingFeeSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncomingFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSTMAmtSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSTMAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn STFAmountSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn STFAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn STFFeeSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn STFFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutgoingSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncomingSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettlementCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantSTMAc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservedForUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn STFDate;
    }
}